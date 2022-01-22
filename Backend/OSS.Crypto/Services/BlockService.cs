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

        public async Task<List<BlockResponse>> GetBlocks(int count)
        {
            var blockHeight = await _client.GetBlockCount();

            var result = new List<BlockResponse>();

            for (var i = 0; i < count; i++)
            {
                result.Add(await _client.GetBlock(blockHeight--));                
            }            

            return result;
        }

    }
}
