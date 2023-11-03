import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { RequisicoesService } from '../../servicos/requisicoes.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AutenticadorService } from 'src/app/servicos/autenticador.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  constructor(private router: Router
    , private requisicoes: RequisicoesService<any>
    , public formBuilder: FormBuilder
    , public autenticadorService: AutenticadorService
    ) {}

  formularioLogin: FormGroup = new FormGroup({});

  ngOnInit(): void {
    this.formularioLogin = this.formBuilder.group({
      dataLogin: [new Date(), [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]],
    });
  }

  get dadosFormulario() {
    return this.formularioLogin.controls;
  }

  Login() {
    const dadosFormulario = {
      dataLogin: this.dadosFormulario['dataLogin'].value,
      email: this.dadosFormulario['email'].value,
      senha: this.dadosFormulario['senha'].value,
    };

    this.requisicoes.criar(`login`, dadosFormulario).subscribe(
      token => {
        this.autenticadorService.setToken(token);
        this.autenticadorService.setEmailUsuario(this.dadosFormulario['email']?.value);
        this.autenticadorService.UsuarioAutenticado(true);
        this.router.navigate(['/pagina-inicial']);
      },
      (error) => {
        console.error('Erro no login', error);
      }
    );
  }
}
