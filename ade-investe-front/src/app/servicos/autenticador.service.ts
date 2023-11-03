
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})

export class AutenticadorService {
    private usuarioAutenticadoPortal: boolean = false;
    private token: any;
    private usuario: any;

    constructor(private httpClient: HttpClient) {
    }

    checkToken() {
        return Promise.resolve(true);
    }

    UsuarioAutenticado(status: boolean) {
        localStorage.setItem('usuarioAutenticadoPortal', JSON.stringify(status));
        this.usuarioAutenticadoPortal = status;
    }

    UsuarioEstaAutenticado(): Promise<boolean> {
        this.usuarioAutenticadoPortal = localStorage.getItem('usuarioAutenticadoPortal') == 'true';
        return Promise.resolve(this.usuarioAutenticadoPortal);
    }

    setToken(token: string) {
        localStorage.setItem('token', token);
        this.token = token;
    }

    get getToken() {
        this.token = localStorage.getItem('token');
        return this.token;
    }

    limparToken() {
        this.token = null;
        this.usuario = null;
    }

    limparDadosUsuario() {
        this.UsuarioAutenticado(false);
        this.limparToken();
        localStorage.clear();
        sessionStorage.clear();
    }

    setEmailUsuario(email: string) {
        localStorage.setItem('emailUsuario', email);
    }

     getEmailUsuario() {
        var emailUsuarioLogado = localStorage.getItem('emailUsuario');
        if (emailUsuarioLogado) {
            return emailUsuarioLogado;
        }
        else {
            this.limparDadosUsuario();
            return "";
        }
    }
}
