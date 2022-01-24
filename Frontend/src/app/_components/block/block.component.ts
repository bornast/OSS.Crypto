import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlockDetail } from 'src/app/models/BlockDetail';
import { BlockchainService } from 'src/app/_services/blockchain.service';

@Component({
  selector: 'app-block',
  templateUrl: './block.component.html',
  styleUrls: ['./block.component.css']
})
export class BlockComponent implements OnInit {

  block: BlockDetail;
  height: number;

  constructor(private blockchainService: BlockchainService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {

    this.route.params.subscribe(params => {
      if (params['height'] != null) {
        this.height = +params['height'];
        this.blockchainService.getBlock(this.height).subscribe( block => {
          if (block == null) {
            this.router.navigate(['/']);
          } else {            
            this.block = block;
            console.log(this.block);
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
