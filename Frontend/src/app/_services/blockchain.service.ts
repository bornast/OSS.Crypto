import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Block } from '../models/Block';
import { UnconfirmedTransaction } from '../models/UnconfirmedTransaction';
import { FeeEstimate } from '../models/FeeEstimate';
import { BlockDetail } from '../models/BlockDetail';
import { TransactionDetail } from '../models/TransactionDetail';
import { Currency } from '../models/Currency';

@Injectable({
  providedIn: 'root'
})
export class BlockchainService {

    baseUrl = "http://localhost:15969/";

    constructor(private http: HttpClient) { }


    getBlocks(count: number): Observable<Block[]> {
      return this.http.get<Block[]>(this.baseUrl + 'Block/getNewestBlocks/' + count);
    }

    getUnconfirmedTransactions(count: number): Observable<UnconfirmedTransaction[]> {
      return this.http.get<UnconfirmedTransaction[]>(this.baseUrl + 'Transaction/unconfirmed/' + count);
    }

    getFeeEstimate(): Observable<FeeEstimate> {
      return this.http.get<FeeEstimate>(this.baseUrl + 'Transaction/feeEstimates');
    }

    getBlock(param: any): Observable<BlockDetail> {
      if (this.isNumeric(param)) {
        return this.http.get<BlockDetail>(this.baseUrl + 'Block/' + param);
      } else {
        return this.http.get<BlockDetail>(this.baseUrl + 'Block/hash/' + param);
      }            
    }

    getTransaction(txId: string): Observable<TransactionDetail> {
      return this.http.get<TransactionDetail>(this.baseUrl + 'Transaction/' + txId);
    }

    getCurrency(): Observable<Currency> {
      return this.http.get<Currency>(this.baseUrl + 'Transaction/currentValue');
    }

    isNumeric(val: any): boolean {
      return !(val instanceof Array) && (val - parseFloat(val) + 1) >= 0;
    }
}
