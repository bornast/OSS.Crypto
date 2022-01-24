import { BlockDetailTransactions } from "./BlockDetailTransactions";

export class BlockDetail {
  timestamp: string;
  totalTransacted: number;
  size: number;
  nonce: number;
  merkleRoot: string;
  bits: string;
  version: number;
  confirmations: number;
  hash: string;
  height: number;
  transactions: BlockDetailTransactions[]
}
