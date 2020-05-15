import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuctionComponent } from './auction/auction.component';
import { ComitenteComponent } from './comitente/comitente.component';
import { ItemComponent } from './item/item.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ContatoComponent } from './contato/contato.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { AuthGuard } from './auth/auth.guard';


const routes: Routes = [
  {path: 'user', component: UserComponent,
    children: [
      {path: 'login', component: LoginComponent},
      {path: 'registration', component: RegistrationComponent}
    ]
  },

  {path: 'auction', component: AuctionComponent, canActivate: [AuthGuard]},
  {path: 'item', component: ItemComponent, canActivate: [AuthGuard]},
  {path: 'comitente', component: ComitenteComponent, canActivate: [AuthGuard]},
  {path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
  {path: 'contato', component: ContatoComponent, canActivate: [AuthGuard]},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
