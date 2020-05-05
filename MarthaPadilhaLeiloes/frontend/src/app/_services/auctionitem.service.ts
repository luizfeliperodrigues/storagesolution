import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuctionItem } from '../_models/AuctionItem';

@Injectable({
  providedIn: 'root'
})
export class AuctionitemService {
  baseURL = 'http://localhost:5000/api/auctionitem';

  constructor(private http: HttpClient) { }

  getAllAuctionItem(): Observable<AuctionItem[]>{
    return this.http.get<AuctionItem[]>(`${this.baseURL}`);
  }

  getAuctionItemById(id: number): Observable<AuctionItem>{
    return this.http.get<AuctionItem>(`${this.baseURL}/${id}`);
  }

  getAllAuctionItemByAuction(id: number): Observable<AuctionItem[]>{
    return this.http.get<AuctionItem[]>(`${this.baseURL}/getaucionitemsbyauction/${id}`);
  }

}
