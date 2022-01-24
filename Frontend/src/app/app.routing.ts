import { Routes } from "@angular/router";
import { BlockComponent } from "./_components/block/block.component";
import { HomeComponent } from "./_components/home/home.component";
import { MempoolComponent } from "./_components/mempool/mempool.component";
import { TransactionComponent } from "./_components/transaction/transaction.component";

export const AppRoutes: Routes = [
    { path: 'block/:height', component: BlockComponent },
    { path: 'transaction/:txId', component: TransactionComponent },
    { path: 'mempool', component: MempoolComponent },
    { path: 'home', component: HomeComponent },
    { path: '', component: HomeComponent }
];
