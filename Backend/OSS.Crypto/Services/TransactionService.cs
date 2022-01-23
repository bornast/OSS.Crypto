using Microsoft.AspNetCore.Http;
using OSS.Crypto.Dto;
using OSS.Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OSS.Crypto.Services
{
    public class TransactionService
    {
        private readonly BitcoinRpcClientService _client;
        private readonly HttpClient _httpClient;

        public TransactionService(BitcoinRpcClientService client, HttpClient httpClient)
        {
            _client = client;
            _httpClient = httpClient;
        }

        public async Task<TransactionResponse> GetTransaction(string txId)
        {
            var transaction = await _client.GetTransaction(txId);

            double voutValue = 0;
            foreach (var vout in transaction.result.vout)
            {
                voutValue += vout.value;
            }

            double vinValue = 0;
            foreach (var vinTx in transaction.result.vin)
            {
                var decodedScript = await _client.DecodeScript(vinTx.scriptSig.hex);

                var newRawTransaction = await _client.GetTransaction(vinTx.txid);

                foreach (var newVout in newRawTransaction.result.vout)
                {
                    vinValue += newVout.value;
                }
            }

            var fee = vinValue - voutValue;

            return transaction;
        }


        public async Task<FeeEstimateDto> getFeeEstimates()
        {
            var response = await _httpClient.GetAsync("https://api.blockcypher.com/v1/btc/test3");

            var content = await response.Content.ReadAsStringAsync();

            var feeEstimate = JsonSerializer.Deserialize<FeeEstimatesResponse>(content);

            
            return new FeeEstimateDto
            {
                HighPriority = ((double)(((int)Math.Ceiling(feeEstimate.high_fee_per_kb / 1000.0)) * 1000)) / 100000000,
                MediumPriority = ((double)(((int)Math.Ceiling(feeEstimate.medium_fee_per_kb / 1000.0)) * 1000)) / 100000000,
                LowPriority = ((double)(((int)Math.Ceiling(feeEstimate.low_fee_per_kb / 1000.0)) * 1000)) / 100000000
            };
        }

        public async Task<Dictionary<string, BitcoinCurrentValueResponse>> getBitcoinCurrentValue()
        {
            var response = await _httpClient.GetAsync("https://blockchain.info/ticker");

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Dictionary<string, BitcoinCurrentValueResponse>>(content);
        }

        public async Task<List<UnconfirmedTransactionDto>> GetUnconfirmedTransactions(int count)
        {
            var unconfirmedTransactions = await _client.GetUnconfirmedTransactions();

            var result = new List<UnconfirmedTransactionDto>();

            var feeEstimates = await getFeeEstimates();

            foreach (var unconfirmedTransaction in unconfirmedTransactions.result)
            {
                var btcKb = unconfirmedTransaction.Value.fee / unconfirmedTransaction.Value.vsize / 1024;

                var priority = "low";

                if (btcKb >= feeEstimates.HighPriority)
                {
                    priority = "high";
                }
                else if (btcKb >= feeEstimates.MediumPriority)
                {
                    priority = "medium";
                }

                var time = (DateTimeOffset.Now - DateTimeOffset.FromUnixTimeSeconds(unconfirmedTransaction.Value.time)).Minutes;

                var timeString = "";
                
                if (time == 0)
                {
                    timeString = "Less than a minute";
                }
                else
                {
                    timeString = time + " minute ago";
                }

                var tx = new UnconfirmedTransactionDto
                {
                    TransactionHash = unconfirmedTransaction.Key,
                    Fee = unconfirmedTransaction.Value.fee,
                    Priority = priority,
                    Time = timeString,
                    dateTime = DateTimeOffset.FromUnixTimeSeconds(unconfirmedTransaction.Value.time)
                };

                result.Add(tx);

            }


            return result.OrderByDescending(x => x.dateTime).Take(count).ToList();
        }

    }
}
