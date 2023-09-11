import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequisicoesService<T> {

  constructor(private http: HttpClient) { }

  getAll(endpoint: string): Observable<T[]> {
    return this.http.get<T[]>(endpoint);
  }

  get(endpoint: string, id: any): Observable<T> {
    return this.http.get<T>(`${endpoint}/${id}`);
  }

  create(endpoint: string, item: T): Observable<T> {
    return this.http.post<T>(endpoint, item);
  }

  update(endpoint: string, id: any, item: T): Observable<T> {
    return this.http.put<T>(`${endpoint}/${id}`, item);
  }

  delete(endpoint: string, id: any): Observable<void> {
    return this.http.delete<void>(`${endpoint}/${id}`);
  }
}
