import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { RequisicoesService } from '../../servicos/requisicoes.service';

@Component({
  selector: 'app-pagina-inicial',
  templateUrl: './pagina-inicial.component.html',
  styleUrls: ['./pagina-inicial.component.scss']
})
export class PaginaInicialComponent implements OnInit {
public usuario: any;
public ativo = false;

  constructor(
    private route: ActivatedRoute
    , private requisicoes: RequisicoesService<any>
    ) {}

  ngOnInit() {
    const usuarioId = localStorage.getItem('usuarioId');
    if (usuarioId) {
      this.requisicoes.listar('usuario', usuarioId).subscribe((data: any) => {
        this.usuario = data;
        this.ativo = true;
      });
    }
  }

}
