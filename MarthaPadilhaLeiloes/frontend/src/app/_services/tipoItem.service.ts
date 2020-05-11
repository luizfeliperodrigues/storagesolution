import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoItem } from '../_models/TipoItem';

@Injectable({
  providedIn: 'root'
})
export class TipoItemService {
  baseURL = 'http://localhost:5000/api/tipoitem';

constructor(private http: HttpClient) { }

getAllTipos(): Observable<TipoItem[]>{
  return this.http.get<TipoItem[]>(`${this.baseURL}`);
}

getTipoItemById(id: number): Observable<TipoItem>{
  return this.http.get<TipoItem>(`${this.baseURL}/${id}`);
}

postTipoItem(tipoItem: TipoItem) {
  return this.http.post(this.baseURL, tipoItem);
}

putTipoItem(tipoItem: TipoItem) {
  return this.http.put(`${this.baseURL}/${tipoItem.id}`, tipoItem);
}

deleteTipoItem(id: number) {
  return this.http.delete(`${this.baseURL}/${id}`);
}

}
