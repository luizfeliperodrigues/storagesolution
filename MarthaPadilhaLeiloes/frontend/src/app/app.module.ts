import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AppRoutingModule } from './app-routing.module';

import { AuctionService } from './_services/auction.service';
import { ComitenteService } from './_services/comitente.service';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { ComitenteComponent } from './comitente/comitente.component';
import { AuctionComponent } from './auction/auction.component';

import { DateTimeFormatPipePipe } from './_helper/DateTimeFormatPipe.pipe';

@NgModule({
   declarations: [
      AppComponent,
      ComitenteComponent,
      NavComponent,
      AuctionComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule
   ],
   providers: [
      ComitenteService,
      AuctionService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
