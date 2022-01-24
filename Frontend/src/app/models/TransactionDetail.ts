import { TransactionDto } from "./TransactionDto";

export class TransactionDetail {
    txId: string;
    fee: number;
    size: number;
    input: TransactionDto[];
    output: TransactionDto[];
}
