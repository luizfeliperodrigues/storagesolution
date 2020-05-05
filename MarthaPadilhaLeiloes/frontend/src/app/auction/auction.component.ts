import { Component, OnInit, TemplateRef } from '@angular/core';
import { AuctionService } from '../_services/auction.service';
import { Auction } from '../_models/Auction';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-auction',
  templateUrl: './auction.component.html',
  styleUrls: ['./auction.component.css']
})
export class AuctionComponent implements OnInit {
  auctionsFiltrados: Auction[];
  auctions: Auction[];
  filtro: string;
  modalRef: BsModalRef;

  filtrolista: number;

  constructor(
      private auctionService: AuctionService
    , private modalService: BsModalService
  ) { }

  get filtroLista(): number{
    return this.filtrolista;
  }
  set filtroLista(value: number){
    this.filtrolista = value;
    this.auctionsFiltrados = this.filtroLista ? this.filtrarAuctions(this.filtroLista) : this.auctions;
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
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

}
