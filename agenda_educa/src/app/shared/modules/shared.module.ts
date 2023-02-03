import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Módulos
import { MaterialModule } from './material.module';

//Componentes
import { LogoComponent } from '../components/logo/logo.component';
import { FooterComponent } from '../components/footer/footer.component';
import { SpinnerComponent } from '../components/spinner/spinner.component';

//Serviços
import { SnackbarService } from 'src/app/services/shared/snackbar.service';

@NgModule({
  declarations: [LogoComponent, FooterComponent, SpinnerComponent],
  imports: [CommonModule, MaterialModule],
  exports: [MaterialModule, LogoComponent, FooterComponent, SpinnerComponent],
  providers: [SnackbarService],
})
export class SharedModule {}
