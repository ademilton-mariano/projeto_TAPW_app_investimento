import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './paginas/login/login.component';
import { PaginaInicialComponent } from './paginas/pagina-inicial/pagina-inicial.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  {path: 'pagina-inicial', component: PaginaInicialComponent},
  { path: '', redirectTo: '/pagina-inicial', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
