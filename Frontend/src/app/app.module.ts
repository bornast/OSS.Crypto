import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AppRoutes } from './app.routing';
import { BlockComponent } from './_components/block/block.component';
import { CurrencyComponent } from './_components/currency/currency.component';
import { HomeComponent } from './_components/home/home.component';
import { MempoolComponent } from './_components/mempool/mempool.component';
import { TransactionComponent } from './_components/transaction/transaction.component';

@NgModule({
  declarations: [
    AppComponent,
    BlockComponent,
    TransactionComponent,
    MempoolComponent,
    CurrencyComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(AppRoutes),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
