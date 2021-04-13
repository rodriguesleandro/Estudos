import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  widthImg: number = 150;
  marginImg: number = 2;
  isImagemExibida: boolean = true;

  public get filtroLista(){
    return this._filtroLista;
  }
  public set filtroLista(value:string){
    this._filtroLista = value;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this._filtroLista): this.eventos;
  }

  public filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (ev: { tema: string, local:string; }) => ev.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || ev.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1

    );
  }

  private _filtroLista: string = '';


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  exibirImagem(){
    this.isImagemExibida = !this.isImagemExibida
  }

  public getEventos(): void{
    console.log('Puta que pariu');
    this.http.get('https://localhost:5001/api/Eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;

      },
      error => console.log(error)
    );

  }

}
