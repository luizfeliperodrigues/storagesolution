import { Component, OnInit, TemplateRef } from '@angular/core';
import { AuctionService } from '../_services/auction.service';
import { Auction } from '../_models/Auction';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-auction',
  templateUrl: './auction.component.html',
  styleUrls: ['./auction.component.css']
})
export class AuctionComponent implements OnInit {
  auctionsFiltrados: Auction[];
  auctions: Auction[];
  auction: Auction;
  filtro: string;
  registerForm: FormGroup;
  bodyDeleteAuction = '';

  infoSave = 'post';

  filtrolista: number;

  constructor(
      private auctionService: AuctionService
    // , private modalService: BsModalService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
  ) {
    this.localeService.use('pt-br')
   }

  get filtroLista(): number{
    return this.filtrolista;
  }
  set filtroLista(value: number){
    this.filtrolista = value;
    this.auctionsFiltrados = this.filtroLista ? this.filtrarAuctions(this.filtroLista) : this.auctions;
  }

  excludeAuction(auction:Auction, template: any) {
    this.openModal(template);
    this.auction = auction;
    this.bodyDeleteAuction = `Tem certeza que deseja excluir o leilão: ${auction.businessCode}?`;
  }

  confirmDelete(template: any) {
    this.auctionService.deleteAuction(this.auction.id).subscribe(
      () => {
          template.hide();
          this.getAuctions();
        }, error => {
          console.log(error);
        }
    );
  }

  editAuction(auction: Auction, template: any){
    this.infoSave = 'put';
    this.openModal(template);
    this.auction = auction;
    this.registerForm.patchValue(auction);
  }

  newAuction(template: any){
    this.infoSave = 'post';
    this.openModal(template);
  }

  openModal(template: any){
    this.registerForm.reset();
    template.show();
  }

  ngOnInit() {
    this.validation();
    this.getAuctions();
  }

  filtrarAuctions(filtrarPor: number): Auction[] {
    this.filtro = filtrarPor.toLocaleString();
    console.log(this.filtro);
    return this.auctions.filter(
      a => a.businessCode.toLocaleString().indexOf(this.filtro) !== -1
    );
  }

  getAuctions(){
    this.auctionService.getAllAuction().subscribe(
      (_auctions: Auction[]) => {
      this.auctions = _auctions;
      // console.log(_auctions);
      }, error => {
        console.log(error);
    });
  }

  validation(){
    this.registerForm = this.fb.group({
      businessCode: ['',
        [Validators.required, Validators.pattern('[1-9]*')]],
      negotiation: ['',
      [Validators.required, Validators.pattern('[0-1]*')]],
      date: ['',
      [Validators.required]]
    });
  }

  saveAuction(template: any){
    if(this.registerForm.valid){
      if (this.infoSave === 'post') {
        this.auction = Object.assign({}, this.registerForm.value);
        this.auctionService.postAuction(this.auction).subscribe(
          () => {
            template.hide();
            this.getAuctions();
          }, error => {
            console.log(error);
          }
        );
      }

      if (this.infoSave === 'put') {
        this.auction = Object.assign({id: this.auction.id}, this.registerForm.value);
        this.auctionService.putAuction(this.auction).subscribe(
          () => {
            template.hide();
            this.getAuctions();
          }, error => {
            console.log(error);
          }
        );
      }
    }
  }
}
