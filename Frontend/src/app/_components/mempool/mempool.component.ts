import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UnconfirmedTransaction } from 'src/app/models/UnconfirmedTransaction';
import { BlockchainService } from 'src/app/_services/blockchain.service';

@Component({
  selector: 'app-mempool',
  templateUrl: './mempool.component.html',
  styleUrls: ['./mempool.component.css']
})
export class MempoolComponent implements OnInit {

  unconfirmedTransactions: UnconfirmedTransaction[];
  interval: any;

  constructor(private blockchainService: BlockchainService, private router: Router) { }

  ngOnInit() {
    this.loadUnconfirmedTransactions();

    this.interval = setInterval(() => {
      this.loadUnconfirmedTransactions(); // api call
    }, 5000);
  }

  ngOnDestroy() {
    if (this.interval) {
      clearInterval(this.interval);
    }
 }

  loadUnconfirmedTransactions() {
    this.blockchainService.getUnconfirmedTransactions(10)
      .subscribe( unconfirmedTransactions => {        
        this.unconfirmedTransactions = unconfirmedTransactions;
        console.log(this.unconfirmedTransactions);
      }, error => {
        console.log('error loading unconfirmed transactions');
      });
  }

  searchBlock() {
    var blockHeight = ((document.getElementById("blockHeightSearch") as HTMLInputElement).value);
    this.router.navigate(['block/' + blockHeight]);
  }

  searchTransaction() {
    var txId = ((document.getElementById("transactionIdSearch") as HTMLInputElement).value);
    this.router.navigate(['transaction/' + txId]);
  }

}
