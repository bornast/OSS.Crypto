using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{
    public class BitcoinRpcResponse
    {
        public string Result { get; set; }
        public string Error { get; set; }
        public string Id { get; set; }
    }
}
