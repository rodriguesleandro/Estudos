import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(
  // {providedIn: 'root'} //uma forma de injetar dependência
  )
export class EventoService {

  baseURL = 'https://localhost:5001/api/Eventos';

constructor(private http: HttpClient) { }

getEventos(): Observable<Evento[]>{
  return this.http.get<Evento[]>(this.baseURL);
}

getEventosEventosByTema(tema: string): Observable<Evento[]>{
  return this.http.get<Evento[]>(`${this.baseURL}/tema/${tema}`);
}

getEventoById(id: number): Observable<Evento>{
  return this.http.get<Evento>(`${this.baseURL}/${id}`);
}

}
