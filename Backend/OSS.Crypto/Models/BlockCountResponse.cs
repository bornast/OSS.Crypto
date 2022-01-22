using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{
    public class BlockCountResponse
    {
        public int Result { get; set; }
        public string Error { get; set; }
        public string Id { get; set; }
    }
}
