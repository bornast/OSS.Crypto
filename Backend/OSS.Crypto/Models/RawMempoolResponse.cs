using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{
    public class RawMempoolResponse
    {
        public Dictionary<string, RawMempoolResult> result { get; set; }
        public object error { get; set; }
        public object id { get; set; }
    }

    public class RawMempoolResult
    {
        public RawMempoolFees fees { get; set; }
        public int vsize { get; set; }
        public int weight { get; set; }
        public double fee { get; set; }
        public double modifiedfee { get; set; }
        public int time { get; set; }
        public int height { get; set; }
        public int descendantcount { get; set; }
        public int descendantsize { get; set; }
        public int descendantfees { get; set; }
        public int ancestorcount { get; set; }
        public int ancestorsize { get; set; }
        public int ancestorfees { get; set; }
        public string wtxid { get; set; }
        public List<object> depends { get; set; }
        public List<object> spentby { get; set; }
        public bool unbroadcast { get; set; }
    }

    public class RawMempoolFees
    {
        public double @base { get; set; }
        public double modified { get; set; }
        public double ancestor { get; set; }
        public double descendant { get; set; }
    }

    


}
