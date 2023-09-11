import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  idUsuarioLogado: number = 0;

  constructor(private http: HttpClient, private router: Router) {}

  dadosLogin = { email: '', senha: '' };
  dadosCadastro = { nome: '',usuario: '', email: '', senha: '', cpf : '' };
  exibirCadastro = false;
  mensagemCadastro = '';
  private baseUrl = 'https://localhost:44333';

  Login() {
    this.http.post(`${this.baseUrl}/login`, this.dadosLogin).subscribe(
      (response: any) => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('usuario', JSON.stringify(response.usuario));
        this.idUsuarioLogado = response.UserId;
        this.router.navigate(['/pagina-inicial', this.idUsuarioLogado]);
      },
      (error) => {
        console.error('Erro no login', error);
      }
    );
  }

  Cadastro() {
    this.http.post(`${this.baseUrl}/usuario-cadastrar`, this.dadosCadastro).subscribe(
      (response) => {
        this.mensagemCadastro = 'Cadastro realizado com sucesso!';
        this.exibirCadastro = false;
      },
      (error) => {
        this.mensagemCadastro = 'Erro no cadastro';
        console.error('Erro no cadastro', error);
      }
    );
  }

  AbreCadastro() {
    this.exibirCadastro = true;
  }

  FechaCadastro() {
    this.exibirCadastro = false;
  }
}
