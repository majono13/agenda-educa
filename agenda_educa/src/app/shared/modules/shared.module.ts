import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Módulos
import { MaterialModule } from './material.module';

//Componentes
import { LogoComponent } from '../components/logo/logo.component';
import { FooterComponent } from '../components/footer/footer.component';

@NgModule({
  declarations: [LogoComponent, FooterComponent],
  imports: [CommonModule, MaterialModule],
  exports: [MaterialModule, LogoComponent, FooterComponent],
})
export class SharedModule {}
