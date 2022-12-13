import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(
  // {providedIn: 'root'} //outra forma de injeção de dependencia
  )

export class EventoService {

constructor(private http: HttpClient)
{



}

baseURL = 'https://localhost:5001/api/eventos';

public getEvento(): Observable<Evento[]>
{
  return this.http.get<Evento[]>(this.baseURL);
}

public getEventoByTema(tema: string): Observable<Evento[]>
{
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
}

public getEventoById(id: number): Observable<Evento>
{
  return this.http.get<Evento>(`${this.baseURL}/${id}`);
}



}
