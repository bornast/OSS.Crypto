using OSS.Crypto.Dto;
using OSS.Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Services
{
    public class BlockService
    {
        private readonly BitcoinRpcClientService _client;

        public BlockService(BitcoinRpcClientService client)
        {
            _client = client;
        }

        public async Task<List<BlockListDto>> GetBlocks(int count)
        {
            var blockHeight = await _client.GetBlockCount();

            var result = new List<BlockResponse>();

            var result2 = new List<BlockListDto>();

            for (var i = 0; i < count; i++)
            {
                var block = await _client.GetBlock(blockHeight--);
                result.Add(block);

                double totalSent = 0.0;

                foreach (var tx in block.result.tx)
                {
                    totalSent += tx.vout.Sum(x => x.value);
                }                

                var blockList = new BlockListDto
                {
                    Height = block.result.height,
                    Timestamp = DateTimeOffset.FromUnixTimeSeconds(block.result.time).ToString(),
                    Transactions = block.result.tx.Count,
                    TotalSent = totalSent,
                    BlockSize = block.result.size,
                    
                };

                result2.Add(blockList);
            }            


            return result2;
        }

        public async Task<BlockDetailDto> GetBlock(int height)
        {         
            var block = await _client.GetBlock(height);

            var result = new BlockDetailDto();
            result.Hash = block.result.hash;
            result.Height = block.result.height;

            result.Timestamp = DateTimeOffset.FromUnixTimeSeconds(block.result.time).ToString();
            double totalSent = 0.0;

            foreach (var tx in block.result.tx)
            {
                totalSent += tx.vout.Sum(x => x.value);
            }
            result.TotalTransacted = totalSent;
            result.Size = block.result.size;
            result.Nonce = block.result.nonce;
            result.MerkleRoot = block.result.merkleroot;
            result.Bits = block.result.bits;
            result.Version = block.result.version;
            result.Confirmations = block.result.confirmations;
            result.Transactions = new List<BlockDetailTransactions>();

            foreach (var tx in block.result.tx)
            {
                var blockDetailTransaction = new BlockDetailTransactions();
                blockDetailTransaction.TransactionId = tx.txid;
                var input = new List<BlockDetailTransaction>();
                var output = new List<BlockDetailTransaction>();

                foreach (var vou in tx.vout)
                {
                    var blockDetailTx = new BlockDetailTransaction
                    {
                        Address = vou.scriptPubKey.addresses != null ? vou.scriptPubKey.addresses.First() : "NULL data transaction",
                        Value = vou.value
                    };
                    output.Add(blockDetailTx);
                }

                foreach (var vin in tx.vin)
                {
                    var address = "";

                    if (vin.scriptSig != null)
                    {
                        address = (await _client.DecodeScript(vin.scriptSig.hex)).result.segwit.addresses.First();
                    }

                    double val = 0.0;

                    if (vin.txid != null)
                    {
                        var newRawTransaction = await _client.GetTransaction(vin.txid);

                        val = newRawTransaction.result.vout[(int)vin.vout].value;
                    }
                    else
                    {
                        val = tx.vout.Sum(x => x.value);
                    }                                      

                    var transactionDetailTransaction = new TransactionDetailTransaction
                    {
                        Address = address,
                        Value = val
                    };

                    var blockDetailTx = new BlockDetailTransaction
                    {
                        Address = address,
                        Value = tx.vout.Sum(x => x.value)
                    };
                    input.Add(blockDetailTx);
                }

                blockDetailTransaction.Input = input;
                blockDetailTransaction.Output = output;
                result.Transactions.Add(blockDetailTransaction);
            }

            return result;
        }

        public async Task<BlockDetailDto> GetBlock(string hash)
        {
            var block = await _client.GetBlock(hash);

            var result = new BlockDetailDto();
            result.Hash = block.result.hash;
            result.Height = block.result.height;

            result.Timestamp = DateTimeOffset.FromUnixTimeSeconds(block.result.time).ToString();
            double totalSent = 0.0;

            foreach (var tx in block.result.tx)
            {
                totalSent += tx.vout.Sum(x => x.value);
            }
            result.TotalTransacted = totalSent;
            result.Size = block.result.size;
            result.Nonce = block.result.nonce;
            result.MerkleRoot = block.result.merkleroot;
            result.Bits = block.result.bits;
            result.Version = block.result.version;
            result.Confirmations = block.result.confirmations;
            result.Transactions = new List<BlockDetailTransactions>();

            foreach (var tx in block.result.tx)
            {
                var blockDetailTransaction = new BlockDetailTransactions();
                blockDetailTransaction.TransactionId = tx.txid;
                var input = new List<BlockDetailTransaction>();
                var output = new List<BlockDetailTransaction>();

                foreach (var vou in tx.vout)
                {
                    var blockDetailTx = new BlockDetailTransaction
                    {
                        Address = vou.scriptPubKey.addresses != null ? vou.scriptPubKey.addresses.First() : "NULL data transaction",
                        Value = vou.value
                    };
                    output.Add(blockDetailTx);
                }

                foreach (var vin in tx.vin)
                {
                    var address = "";

                    if (vin.scriptSig != null)
                    {
                        address = (await _client.DecodeScript(vin.scriptSig.hex)).result.segwit.addresses.First();
                    }

                    double val = 0.0;

                    if (vin.txid != null)
                    {
                        var newRawTransaction = await _client.GetTransaction(vin.txid);

                        val = newRawTransaction.result.vout[(int)vin.vout].value;
                    }
                    else
                    {
                        val = tx.vout.Sum(x => x.value);
                    }

                    var transactionDetailTransaction = new TransactionDetailTransaction
                    {
                        Address = address,
                        Value = val
                    };

                    var blockDetailTx = new BlockDetailTransaction
                    {
                        Address = address,
                        Value = tx.vout.Sum(x => x.value)
                    };
                    input.Add(blockDetailTx);
                }

                blockDetailTransaction.Input = input;
                blockDetailTransaction.Output = output;
                result.Transactions.Add(blockDetailTransaction);
            }

            return result;
        }
    }
}
