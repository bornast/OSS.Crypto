using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Dto
{
    public class BlockListDto
    {
        public int Height { get; set; }
        public string Timestamp { get; set; }
        public int Transactions { get; set; }
        public double TotalSent { get; set; }
        public double BlockSize { get; set; }
    }
}
