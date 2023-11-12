import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-alerta',
  templateUrl: './alerta.component.html',
  styleUrls: ['./alerta.component.scss']
})
export class AlertaComponent implements OnInit {
  @Input() mensagem: string = '';
  mostrarAlerta: boolean = true;

  constructor() { }

  ngOnInit(): void {
    setTimeout(() => {
      this.mostrarAlerta = false;
    }, 5000);
  }
}
