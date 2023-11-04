import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {

  constructor(private router: Router,) {

  }

   menuSelecionado: number = 1;


  selectMenu(menu: number) {
    switch (menu) {
      case 1:
        this.router.navigate(['/pagina-inicial']);
        break;

      case 2:
        this.router.navigate(['/perfil']);
        break;

        case 100:
          localStorage.clear();
          this.router.navigate(['/']);
          break;

      default:
        break;
    }

    this.menuSelecionado = menu;

  }

}
