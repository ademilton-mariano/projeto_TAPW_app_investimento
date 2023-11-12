import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MAT_MOMENT_DATE_FORMATS,
  MomentDateAdapter,
} from '@angular/material-moment-adapter';
import {
  DateAdapter,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE,
  MatNativeDateModule,
} from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CpfMaskDirective } from './cpf-mask.directive';
import { LoginComponent } from './paginas/login/login.component';
import { PaginaInicialComponent } from './paginas/pagina-inicial/pagina-inicial.component';
import { NavbarModule } from './componentes/navbar/navbar.module';
import { SidebarModule } from './componentes/sidebar/sidebar.module';
import { RequisicoesService } from './servicos/requisicoes.service';
import { AlertaComponent } from './componentes/alerta/alerta.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PaginaInicialComponent,
    CpfMaskDirective,
    AlertaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    NavbarModule,
    SidebarModule,
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
    { provide: DateAdapter, useClass: MomentDateAdapter },
    { provide: HTTP_INTERCEPTORS, useClass: RequisicoesService, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
