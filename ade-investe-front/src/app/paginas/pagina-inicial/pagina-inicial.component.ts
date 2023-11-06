import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AutenticadorService } from 'src/app/servicos/autenticador.service';

import { RequisicoesService } from '../../servicos/requisicoes.service';

@Component({
  selector: 'app-pagina-inicial',
  templateUrl: './pagina-inicial.component.html',
  styleUrls: ['./pagina-inicial.component.scss'],
})
export class PaginaInicialComponent {
  conta = {
    id: 0,
    saldo: 0,
    ativo: '',
    usuarioClienteNome: '',
    criadoDataHora: '',
    investimentoNome: '',
    investimentoId: 0,
    investimentoRendimentoEmPorcentagem: 0,
    investimentoResgate: 0,
  };

  mostrarInvestirForm: boolean = false;
  mostrarResgatarForm: boolean = false;
  formularioInvestir: FormGroup;
  formularioResgatar: FormGroup;
  rendimento: number = 0.0;

  constructor(
    private formBuilder: FormBuilder,
    private requisicoes: RequisicoesService<any>,
    public autenticadorService: AutenticadorService
  ) {
    this.formularioInvestir = this.formBuilder.group({
      valorInvestimento: ['', [Validators.required, Validators.min(0.01)]],
    });

    this.formularioResgatar = this.formBuilder.group({
      valorResgate: ['', [Validators.required, Validators.min(0.01)]],
    });
  }

  ngOnInit(): void {
    const idUsuario = this.autenticadorService.getUsuario()?.id;

    if (!idUsuario) {
      return;
    }

    const idInt = parseInt(idUsuario, 10);

    this.requisicoes.listar('conta', idInt).subscribe(
      (resposta: any) => {
        this.conta = resposta;
        this.conta.ativo = resposta.ativo === true ? 'Ativa' : 'Inativa';
        this.conta.criadoDataHora = new Date(resposta.criadoDataHora)
          .getDate()
          .toString();
      },
      (error) => {
        console.error('Erro ao buscar conta', error);
      }
    );
  }

  AbrirInvestirForm() {
    this.mostrarInvestirForm = true;
  }

  FecharInvestirForm() {
    this.mostrarInvestirForm = false;
  }

  Investir() {
    const dadosFormulario = {
      valor: this.formularioInvestir.get('valorInvestimento')?.value,
      id: this.conta.id,
      tipo: 'Investimento',
    };

    this.requisicoes.criar(`movimentacao`, dadosFormulario).subscribe(
      (resposta) => {
        this.ngOnInit();
        this.FecharInvestirForm();
      },
      (error) => {
        console.error('Erro ao investir', error);
      }
    );
  }

  AbrirResgatarForm() {
    this.mostrarResgatarForm = true;
  }

  CalculoRendimento() {}

  FecharResgatarForm() {
    this.mostrarResgatarForm = false;
  }

  Resgatar() {
    // Lógica para resgatar
  }
}
