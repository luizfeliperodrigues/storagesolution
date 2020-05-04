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

}
