import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgxMaskModule.forRoot(),
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt-BR' }, // Usado para utilizar o Angular em pt-BR
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }, // Usado para utilizar o Material em pt-BR
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
