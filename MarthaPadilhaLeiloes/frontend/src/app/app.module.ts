import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';

import { AuctionService } from './_services/auction.service';
import { ComitenteService } from './_services/comitente.service';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ComitenteComponent } from './comitente/comitente.component';
import { AuctionComponent } from './auction/auction.component';
import { ItemComponent } from './item/item.component';
import { ContatoComponent } from './contato/contato.component';
import { TituloComponent } from './_shared/titulo/titulo.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';

import { DateTimeFormatPipePipe } from './_helper/DateTimeFormatPipe.pipe';
import { AuthInterceptor } from './auth/auth.interceptor';
import { ItemService } from './_services/item.service';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      DashboardComponent,
      ComitenteComponent,
      AuctionComponent,
      ItemComponent,
      ContatoComponent,
      TituloComponent,
      ContatoComponent,
      UserComponent,
      LoginComponent,
      RegistrationComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
      ReactiveFormsModule
   ],
   providers: [
      ComitenteService,
      AuctionService,
      ItemService,
      {
         provide: HTTP_INTERCEPTORS,
         useClass: AuthInterceptor,
         multi: true
      }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
