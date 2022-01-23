using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Dto
{
    public class FeeEstimateDto
    {
        public double HighPriority { get; set; }
        public double MediumPriority { get; set; }
        public double LowPriority { get; set; }
    }
}
