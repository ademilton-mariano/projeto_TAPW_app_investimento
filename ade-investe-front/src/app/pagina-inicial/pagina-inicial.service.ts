import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PaginaInicialService {
  constructor(private http: HttpClient) {}

  ListarUsuarioPorId(usuarioId: string) {
    // Substitua a URL pelo endpoint correto do seu backend
    return this.http.get(`/api/user/${usuarioId}`);
  }
}
