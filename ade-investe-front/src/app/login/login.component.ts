import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {

  idUsuarioLogado: number = 0;

  constructor(private http: HttpClient, private router: Router) {}

  dadosLogin = { dataLogin: new Date(''), email: '', senha: '' };
  dadosCadastro = { nome: '', email: '', senha: '', cpf : '', dataNascimento: new Date('') };
  exibirCadastro = false;
  mensagemCadastro = '';
  private baseUrl = 'https://localhost:44333';

  Login() {
    this.dadosLogin.dataLogin = new Date(this.dadosLogin.dataLogin);

    this.http.post(`${this.baseUrl}/login`, this.dadosLogin).subscribe(
      (response: any) => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('usuario', JSON.stringify(response.usuario));
        this.idUsuarioLogado = response.UsuarioId;
        this.router.navigate(['/pagina-inicial']);
      },
      (error) => {
        console.error('Erro no login', error);
      }
    );
  }

  Cadastro() {
    this.dadosCadastro.dataNascimento = new Date(this.dadosCadastro.dataNascimento);
    this.dadosCadastro.cpf = this.dadosCadastro.cpf.replace(/\D/g, '');

    this.http.post(`${this.baseUrl}/usuario-cadastrar`, this.dadosCadastro, { responseType: 'text' }).subscribe(
      (response) => {
        if (response && response.toLowerCase().includes('usuário cadastrado com sucesso')) {
          this.mensagemCadastro = 'Cadastro realizado com sucesso!';
          this.exibirCadastro = false;
        } else {
          this.mensagemCadastro = 'Erro no cadastro';
          console.error('Erro no cadastro');
        }
      },
      (error) => {
        this.mensagemCadastro = 'Erro no cadastro';
        console.error('Erro no cadastro', error);
      }
    );
  }

  AbreCadastro() {
    this.dadosCadastro = { nome: '', email: '', senha: '', cpf : '', dataNascimento: new Date('') };
    this.exibirCadastro = true;
  }

  FechaCadastro() {
    this.exibirCadastro = false;
  }
}
