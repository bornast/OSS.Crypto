import { Component, OnInit } from '@angular/core';
import { Block } from 'src/app/models/Block';
import { FeeEstimate } from 'src/app/models/FeeEstimate';
import { UnconfirmedTransaction } from 'src/app/models/UnconfirmedTransaction';
import { BlockchainService } from 'src/app/_services/blockchain.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  blocks: Block[];
  unconfirmedTransactions: UnconfirmedTransaction[];
  feeEstimate: FeeEstimate;

  constructor(private blockchainService: BlockchainService) { }

  ngOnInit() {
    this.loadBlocks();
    this.loadUnconfirmedTransactions();
    this.loadFeeEstimate();
  }

  loadBlocks() {
    this.blockchainService.getBlocks(5)
      .subscribe( blocks => {        
        this.blocks = blocks;
        console.log(this.blocks);
      }, error => {
        console.log('error loading blocks');
      });
  }

  loadUnconfirmedTransactions() {
    this.blockchainService.getUnconfirmedTransactions(5)
      .subscribe( unconfirmedTransactions => {        
        this.unconfirmedTransactions = unconfirmedTransactions;
        console.log(this.unconfirmedTransactions);
      }, error => {
        console.log('error loading unconfirmed transactions');
      });
  }

  loadFeeEstimate() {
    this.blockchainService.getFeeEstimate()
      .subscribe( feeEstimate => {        
        this.feeEstimate = feeEstimate;
        console.log(this.feeEstimate);
      }, error => {
        console.log('error loading fee estimates');
      });
  }

}
