import { TransactionDto } from "./TransactionDto";

export class BlockDetailTransactions {
    transactionId: number;
    input: TransactionDto[];
    output: TransactionDto[];
}
