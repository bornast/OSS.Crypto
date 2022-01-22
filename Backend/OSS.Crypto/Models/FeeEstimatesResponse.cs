using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Models
{
    public class FeeEstimatesResponse
    {
        public string name { get; set; }
        public int height { get; set; }
        public string hash { get; set; }
        public string time { get; set; }
        public string latest_url { get; set; }
        public string previous_hash { get; set; }
        public string previous_url { get; set; }
        public int peer_count { get; set; }
        public int unconfirmed_count { get; set; }
        public int high_fee_per_kb { get; set; }
        public int medium_fee_per_kb { get; set; }
        public int low_fee_per_kb { get; set; }
        public int last_fork_height { get; set; }
        public string last_fork_hash { get; set; }
    }
}
