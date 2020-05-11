import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item } from '../_models/Item';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  baseURL = 'http://localhost:5000/api/item';

constructor(private http: HttpClient) { }

getAllItems(): Observable<Item[]>{
  return this.http.get<Item[]>(`${this.baseURL}`);
}

getItemById(id: number): Observable<Item>{
  return this.http.get<Item>(`${this.baseURL}/${id}`);
}

postItem(item: Item) {
  return this.http.post(this.baseURL, item);
}

putItem(item: Item) {
  return this.http.put(`${this.baseURL}/${item.id}`, item);
}

deleteItem(id: number) {
  return this.http.delete(`${this.baseURL}/${id}`);
}

}
