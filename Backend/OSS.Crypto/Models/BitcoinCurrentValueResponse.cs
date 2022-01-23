using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{
    public class BitcoinCurrentValueResponse
    {
        public double _15m { get; set; }
        public double last { get; set; }
        public double buy { get; set; }
        public double sell { get; set; }
        public string symbol { get; set; }
    }
}
