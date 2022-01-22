using Microsoft.AspNetCore.Http;
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


        public async Task<FeeEstimatesResponse> getFeeEstimates()
        {
            var response = await _httpClient.GetAsync("https://api.blockcypher.com/v1/btc/test3");

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<FeeEstimatesResponse>(content);
        }

    }
}
