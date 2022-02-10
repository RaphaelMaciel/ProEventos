import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public eventosFiltrados: any = []
  changecollapsestatus= true;
  isCollapsed = false;
  private _filtroLista = '';

  public get filtroLista(){
    return this._filtroLista
  }
  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }
  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  this.getEventos();
  }

  changecollapse(){
    this.changecollapsestatus = !this.changecollapsestatus;
  }

  public getEventos(): void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
  }
}
