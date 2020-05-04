import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Comitente } from '../_models/Comitente';

@Injectable({
  providedIn: 'root'
})
export class ComitenteService {
  baseURL = 'http://localhost:5000/api/comitente';

  constructor(private http: HttpClient) { }

  getAllComitente(): Observable<Comitente[]>{
    return this.http.get<Comitente[]>(`${this.baseURL}`);
  }

  getComitenteById(id: number): Observable<Comitente>{
    return this.http.get<Comitente>(`${this.baseURL}/${id}`);
  }

}
