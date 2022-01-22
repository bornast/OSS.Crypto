using OSS.Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Services
{
    public class TransactionService
    {
        private readonly BitcoinRpcClientService _client;

        public TransactionService(BitcoinRpcClientService client)
        {
            _client = client;
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
    }
}
