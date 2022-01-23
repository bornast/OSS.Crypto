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
                    totalSent = tx.vout.Sum(x => x.value);
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

        public async Task<BlockResponse> GetBlock(int height)
        {            
            return await _client.GetBlock(height);
        }

    }
}
