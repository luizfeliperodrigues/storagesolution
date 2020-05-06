import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Auction } from '../_models/Auction';

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  baseURL = 'http://localhost:5000/api/auction';

constructor(private http: HttpClient) { }

getAllAuction(): Observable<Auction[]>{
  return this.http.get<Auction[]>(`${this.baseURL}`);
}

getAuctionById(id: number): Observable<Auction>{
  return this.http.get<Auction>(`${this.baseURL}/${id}`);
}

postAuction(auction: Auction) {
  return this.http.post(this.baseURL, auction);
}

putAuction(auction: Auction) {
  return this.http.put(`${this.baseURL}/${auction.id}`, auction);
}

deleteAuction(id: number) {
  return this.http.delete(`${this.baseURL}/${id}`);
}

}
