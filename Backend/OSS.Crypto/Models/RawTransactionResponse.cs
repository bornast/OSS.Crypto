using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{
    public class RawTransactionResponse
    {
        public string result { get; set; }
        public string error { get; set; }
        public string id { get; set; }
    }
}
