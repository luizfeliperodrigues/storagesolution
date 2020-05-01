import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-comitente',
  templateUrl: './comitente.component.html',
  styleUrls: ['./comitente.component.css']
})
export class ComitenteComponent implements OnInit {

  _filtroLista: string;
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value;
    this.comitentesFiltrados = this.filtroLista ? this.filtrarComitentes(this.filtroLista) : this.comitentes;
  }

  comitentesFiltrados: any = [];
  comitentes: any = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getComitentes();
  }

  filtrarComitentes(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.comitentes.filter(
      c => c.comitenteName.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  getComitentes(){
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.comitentes = response;
      console.log(response);
      }, error => {
        console.log(error);
    });
  }

}
