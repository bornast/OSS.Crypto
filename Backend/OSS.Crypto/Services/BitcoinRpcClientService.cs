using BitcoinRpc;
using BitcoinRpc.CoreRPC;
using OSS.Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace OSS.Crypto.Services
{
    public class BitcoinRpcClientService
    {
        private readonly BitcoinServerSettings _settings;
        private readonly Blockchain _blockchain;
        private readonly RawTransaction _rawTransaction;

        public BitcoinRpcClientService(BitcoinServerSettings settings)
        {
            _settings = settings;
            var bitcoinClient = new BitcoinClient(settings.Url, 
                settings.Username + ":" + settings.Password);
            _blockchain = new Blockchain(bitcoinClient);
            _rawTransaction = new RawTransaction(bitcoinClient);
        }

        public async Task<int> GetBlockCount()
        {
            string response = await _blockchain.GetBlockCount();

            var result = JsonSerializer.Deserialize<BlockCountResponse>(response, 
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result.Result;
        }

        public async Task<BlockResponse> GetBlock(int height)
        {
            string response = await _blockchain.GetBlockHash(height);

            var responseObj = JsonSerializer.Deserialize<BitcoinRpcResponse>(response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            var block = await GetBlock(responseObj.Result);            

            return block;
        }

        public async Task<BlockResponse> GetBlock(string hash)
        {            
            string response = await _blockchain.GetBlock(hash, BitcoinRpc.Enums.Verbosity.VerbosityTwo);

            var responseObj = JsonSerializer.Deserialize<BlockResponse>(response);

            return responseObj;
        }


        public async Task<TransactionResponse> GetTransaction(string txId)
        {
            string rawTransactionResponse = await _rawTransaction.GetRawTransaction(txId);

            var rawTransactionResponseObj = JsonSerializer.Deserialize<RawTransactionResponse>(rawTransactionResponse);

            var decodedTransactionResponse = await _rawTransaction.DecodeRawTransaction(rawTransactionResponseObj.result);
            
            return JsonSerializer.Deserialize<TransactionResponse>(decodedTransactionResponse);
        }

        public async Task<DecodeScriptResponse> DecodeScript(string hex)
        {
            var response = await _rawTransaction.DecodeScript(hex);

            return JsonSerializer.Deserialize<DecodeScriptResponse>(response);            
        }

        public async Task<RawMempoolResponse> GetUnconfirmedTransactions()
        {
            var response = await _blockchain.GetRawMempool();

            return JsonSerializer.Deserialize<RawMempoolResponse>(response);
        }

    }
}
