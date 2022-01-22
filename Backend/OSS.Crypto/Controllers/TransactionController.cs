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
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{txId}")]
        public async Task<TransactionResponse> Get(string txId)
        {
            return await _transactionService.GetTransaction(txId);
        }
    }
}
