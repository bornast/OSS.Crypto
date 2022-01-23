import { Routes } from "@angular/router";
import { BlockComponent } from "./_components/block/block.component";
import { HomeComponent } from "./_components/home/home.component";
import { TransactionComponent } from "./_components/transaction/transaction.component";

export const AppRoutes: Routes = [
    { path: 'block/:id', component: BlockComponent },
    { path: 'transaction/:id', component: TransactionComponent },
    { path: 'home', component: HomeComponent },
    { path: '', component: HomeComponent }
];
