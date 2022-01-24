import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionDetail } from 'src/app/models/TransactionDetail';
import { BlockchainService } from 'src/app/_services/blockchain.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {

  transaction: TransactionDetail;
  txId: string;;

  constructor(private blockchainService: BlockchainService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params['txId'] != null) {
        this.txId = params['txId'];
        this.blockchainService.getTransaction(this.txId).subscribe( transaction => {
          if (transaction == null) {
            this.router.navigate(['/']);
          } else {            
            this.transaction = transaction;
            console.log(this.transaction);
          }
        }, error => {
          this.router.navigate(['/']);
      });
      }
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
