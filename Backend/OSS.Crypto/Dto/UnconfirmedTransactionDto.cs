using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Dto
{
    public class UnconfirmedTransactionDto
    {
        public string TransactionHash { get; set; }
        public double Fee { get; set; }
        public string Priority { get; set; }
        public string Time { get; set; }
        public DateTimeOffset dateTime { get; set; }
    }
}
