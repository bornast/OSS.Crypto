import { Component, OnInit } from '@angular/core';
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

  constructor(private blockchainService: BlockchainService) { }

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

}
