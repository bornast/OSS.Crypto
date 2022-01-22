using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{

    public class TransactionResponse
    {
        public TransactionResult result { get; set; }
        public object error { get; set; }
        public object id { get; set; }
    }

    public class TransactionScriptSig
    {
        public string asm { get; set; }
        public string hex { get; set; }
    }

    public class TransactionVin
    {
        public string txid { get; set; }
        public int vout { get; set; }
        public TransactionScriptSig scriptSig { get; set; }
        public List<string> txinwitness { get; set; }
        public long sequence { get; set; }
    }

    public class TransactionScriptPubKey
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public int reqSigs { get; set; }
        public string type { get; set; }
        public List<string> addresses { get; set; }
    }

    public class TransactionVout
    {
        public double value { get; set; }
        public int n { get; set; }
        public TransactionScriptPubKey scriptPubKey { get; set; }
    }

    public class TransactionResult
    {
        public string txid { get; set; }
        public string hash { get; set; }
        public int version { get; set; }
        public int size { get; set; }
        public int vsize { get; set; }
        public int weight { get; set; }
        public int locktime { get; set; }
        public List<TransactionVin> vin { get; set; }
        public List<TransactionVout> vout { get; set; }
    }    

}
