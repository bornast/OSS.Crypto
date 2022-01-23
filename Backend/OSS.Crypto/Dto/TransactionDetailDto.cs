using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Dto
{
    public class TransactionDetailDto
    {
        public string TxId { get; set; }
        public double Fee { get; set; }
        public int Size { get; set; }
        public List<TransactionDetailTransaction> Input { get; set; } = new List<TransactionDetailTransaction>();
        public List<TransactionDetailTransaction> Output { get; set; } = new List<TransactionDetailTransaction>();
    }

    public class TransactionDetailTransaction
    {
        public string Address { get; set; }
        public double Value { get; set; }
    }
}
