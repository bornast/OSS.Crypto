using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{

    public class DecodeScriptResponse
    {
        public DecodeScriptResult result { get; set; }
        public object error { get; set; }
        public object id { get; set; }
    }

    public class DecodeScriptSegwit
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public int reqSigs { get; set; }
        public string type { get; set; }
        public List<string> addresses { get; set; }
    }

    public class DecodeScriptResult
    {
        public string asm { get; set; }
        public string type { get; set; }
        public string p2sh { get; set; }
        public DecodeScriptSegwit segwit { get; set; }
    }


}
