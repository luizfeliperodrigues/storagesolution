import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuctionComponent } from './auction/auction.component';
import { ComitenteComponent } from './comitente/comitente.component';
import { ItemComponent } from './item/item.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ContatoComponent } from './contato/contato.component';


const routes: Routes = [
  {path: 'auction', component: AuctionComponent},
  {path: 'item', component: ItemComponent},
  {path: 'comitente', component: ComitenteComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'contato', component: ContatoComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
