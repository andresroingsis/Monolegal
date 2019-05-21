import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientesComponent } from './vistas/clientes/clientes.component';
import { FacturasComponent } from './vistas/facturas/facturas.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    FacturasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
