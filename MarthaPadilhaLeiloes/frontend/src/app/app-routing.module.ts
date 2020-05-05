import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuctionComponent } from './auction/auction.component';
import { ComitenteComponent } from './comitente/comitente.component';


const routes: Routes = [
  {path: 'auction', component: AuctionComponent},
  {path: 'comitente', component: ComitenteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
