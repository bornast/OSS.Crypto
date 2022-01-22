using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OSS.Crypto.Models;
using OSS.Crypto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockController : ControllerBase
    {
        private readonly BlockService _blockService;

        public BlockController(BlockService blockService)
        {
            _blockService = blockService;
        }

        [HttpGet("list/{count}")]
        public async Task<List<BlockResponse>> Get(int count)
        {
            return await _blockService.GetBlocks(count);
        }
    }
}
