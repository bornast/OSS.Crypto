using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{
    public class BlockResponse
    {
        public BlockResult result { get; set; }
        public object error { get; set; }
        public object id { get; set; }
    }

    public class BlockScriptSig
    {
        public string asm { get; set; }
        public string hex { get; set; }
    }

    public class BlockVin
    {
        public string coinbase { get; set; }
        public List<string> txinwitness { get; set; }
        public object sequence { get; set; }
        public string txid { get; set; }
        public int? vout { get; set; }
        public BlockScriptSig scriptSig { get; set; }
    }

    public class BlockScriptPubKey
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public int reqSigs { get; set; }
        public string type { get; set; }
        public List<string> addresses { get; set; }
    }

    public class BlockVout
    {
        public double value { get; set; }
        public int n { get; set; }
        public BlockScriptPubKey scriptPubKey { get; set; }
    }

    public class Tx
    {
        public string txid { get; set; }
        public string hash { get; set; }
        public int version { get; set; }
        public int size { get; set; }
        public int vsize { get; set; }
        public int weight { get; set; }
        public int locktime { get; set; }
        public List<BlockVin> vin { get; set; }
        public List<BlockVout> vout { get; set; }
        public string hex { get; set; }
    }

    public class BlockResult
    {
        public string hash { get; set; }
        public int confirmations { get; set; }
        public int strippedsize { get; set; }
        public int size { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public int version { get; set; }
        public string versionHex { get; set; }
        public string merkleroot { get; set; }
        public List<Tx> tx { get; set; }
        public int time { get; set; }
        public int mediantime { get; set; }
        public long nonce { get; set; }
        public string bits { get; set; }
        public double difficulty { get; set; }
        public string chainwork { get; set; }
        public int nTx { get; set; }
        public string previousblockhash { get; set; }
    }

    


}
