import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-comitente',
  templateUrl: './comitente.component.html',
  styleUrls: ['./comitente.component.css']
})
export class ComitenteComponent implements OnInit {
  comitentes: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getComitentes();
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
