import { Component, OnInit } from '@angular/core';
import { Currency } from 'src/app/models/Currency';
import { BlockchainService } from 'src/app/_services/blockchain.service';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.css']
})
export class CurrencyComponent implements OnInit {

  currencies: Currency;
  currenciesMap: Map<string, number>;
  convertedValue: number;
  btcValue: number;
  selectedOption: string;

  constructor(private blockchainService: BlockchainService) { }

  ngOnInit() {
    this.loadCurrencies();
  }

  loadCurrencies() {
    this.blockchainService.getCurrency()
      .subscribe( currencies => {        
        this.currencies = currencies;
        this.currenciesMap = new Map<string, number>();
        for (const [key, value] of Object.entries(this.currencies)) {
          this.currenciesMap.set(key, value["last"]);
        }
        console.log(this.currencies);
        console.log(this.currenciesMap);
      }, error => {
        console.log('error loading currencies');
      });
  }

  convert() {
    if (this.currenciesMap.get(this.selectedOption) && this.btcValue) {
      let val = this.currenciesMap.get(this.selectedOption);
      if (val) {
        this.convertedValue = this.btcValue * val;
      }
    }
  }

}
