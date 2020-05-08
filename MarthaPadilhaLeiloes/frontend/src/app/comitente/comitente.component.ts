import { Component, OnInit } from '@angular/core';
import { ComitenteService } from '../_services/comitente.service';
import { Comitente } from '../_models/Comitente';

@Component({
  selector: 'app-comitente',
  templateUrl: './comitente.component.html',
  styleUrls: ['./comitente.component.css']
})
export class ComitenteComponent implements OnInit {
  title = 'Comitentes';
  filtrolista: string;
  get filtroLista(): string{
    return this.filtrolista;
  }
  set filtroLista(value: string){
    this.filtrolista = value;
    this.comitentesFiltrados = this.filtroLista ? this.filtrarComitentes(this.filtroLista) : this.comitentes;
  }

  comitentesFiltrados: Comitente[];
  comitentes: Comitente[];

  constructor(private comitenteService: ComitenteService) { }

  ngOnInit() {
    this.getComitentes();
  }

  filtrarComitentes(filtrarPor: string): Comitente[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.comitentes.filter(
      c => c.name.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  getComitentes(){
    this.comitenteService.getAllComitente().subscribe(
      (_comitentes: Comitente[]) => {
      this.comitentes = _comitentes;
      console.log(_comitentes);
      }, error => {
        console.log(error);
    });
  }

}
