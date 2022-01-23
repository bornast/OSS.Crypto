using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSS.Crypto.Dto
{
    public class BlockDetailDto
    {
        public string Timestamp { get; set; }
        public double TotalTransacted { get; set; }
        public double Size { get; set; }
        public long Nonce { get; set; }
        public string MerkleRoot { get; set; }
        public string Bits { get; set; }
        public int Version { get; set; }
        public int Confirmations { get; set; }
        public List<BlockDetailTransactions> Transactions { get; set; }
    }

    public class BlockDetailTransactions
    {
        public List<BlockDetailTransaction> Input { get; set; }
        public List<BlockDetailTransaction> Output { get; set; }
    }

    public class BlockDetailTransaction
    {
        public string Address { get; set; }
        public double Value { get; set; }
    }

}
