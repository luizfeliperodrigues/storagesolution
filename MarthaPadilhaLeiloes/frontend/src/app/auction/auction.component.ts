import { Component, OnInit, TemplateRef } from '@angular/core';
import { AuctionService } from '../_services/auction.service';
import { Auction } from '../_models/Auction';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
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
  title = 'Leilões';
  auctionsFiltrados: Auction[];
  auctions: Auction[];
  auction: Auction;
  registerForm: FormGroup;
  bodyDeleteAuction = '';

  infoSave = 'post';

  filtrolista: string;

  constructor(
      private auctionService: AuctionService
    // , private modalService: BsModalService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
    , private toastr: ToastrService
  ) {
    this.localeService.use('pt-br');
   }

  get filtroLista(): string{
    return this.filtrolista;
  }
  set filtroLista(value: string){
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
          this.toastr.success('Deletado com sucesso!');
        }, error => {
          this.toastr.error('Erro ao tentar deletar.');
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

  filtrarAuctions(filtrarPor: string): Auction[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.auctions.filter(
      i => {
        const aux = i.businessCode + '';
        return aux.indexOf(filtrarPor) !== -1;
      }
    );
  }

  getAuctions(){
    this.auctionService.getAllAuction().subscribe(
      (_auctions: Auction[]) => {
      this.auctions = _auctions;
      // console.log(_auctions);
      }, error => {
        this.toastr.error(`Erro ao tentar carregar os leilões: ${error}`);
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
            this.toastr.success('Leilão criado com sucesso!');
          }, error => {
            this.toastr.error(`Erro ao criar o leilão: ${error}`);
          }
        );
      }

      if (this.infoSave === 'put') {
        this.auction = Object.assign({id: this.auction.id}, this.registerForm.value);
        this.auctionService.putAuction(this.auction).subscribe(
          () => {
            template.hide();
            this.getAuctions();
            this.toastr.success('Leilão editado com sucesso!');
          }, error => {
            this.toastr.error(`Erro ao editar o leilão: ${error}`);
          }
        );
      }
    }
  }
}
