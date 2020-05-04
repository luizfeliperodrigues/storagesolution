import { Component, OnInit } from '@angular/core';
import { AuctionService } from '../_services/auction.service';
import { Auction } from '../_models/Auction';

@Component({
  selector: 'app-auction',
  templateUrl: './auction.component.html',
  styleUrls: ['./auction.component.css']
})
export class AuctionComponent implements OnInit {

  filtrolista: number;
  get filtroLista(): number{
    return this.filtrolista;
  }
  set filtroLista(value: number){
    this.filtrolista = value;
    this.auctionsFiltrados = this.filtroLista ? this.filtrarAuctions(this.filtroLista) : this.auctions;
  }

  auctionsFiltrados: Auction[];
  auctions: Auction[];
  filtro: string;

  constructor(private auctionService: AuctionService) { }

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
