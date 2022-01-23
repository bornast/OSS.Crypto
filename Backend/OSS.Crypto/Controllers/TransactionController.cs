using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OSS.Crypto.Dto;
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
        public async Task<TransactionDetailDto> Get(string txId)
        {
            return await _transactionService.GetTransaction(txId);
        }


        [HttpGet("feeEstimates")]
        public async Task<FeeEstimateDto> GetFeeEstimates()
        {
            return await _transactionService.getFeeEstimates();
        }

        [HttpGet("currentValue")]
        public async Task<Dictionary<string, BitcoinCurrentValueResponse>> GetBitcoinCurrentValue()
        {
            return await _transactionService.getBitcoinCurrentValue();
        }


        [HttpGet("unconfirmed/{count}")]
        public async Task<List<UnconfirmedTransactionDto>> GetUnconfirmedTransactions(int count)
        {
            return await _transactionService.GetUnconfirmedTransactions(count);
        }

    }
    
}
