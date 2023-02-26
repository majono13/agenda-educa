import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Módulos
import { MaterialModule } from './material.module';
import { HttpClientModule } from '@angular/common/http';

//Componentes
import { LogoComponent } from '../components/logo/logo.component';
import { FooterComponent } from '../components/footer/footer.component';
import { SpinnerComponent } from '../components/spinner/spinner.component';
import { NavbarComponent } from '../components/navbar/navbar.component';
import { LoadingScreenComponent } from '../components/loading-screen/loading-screen.component';

//Serviços
import { SnackbarService } from 'src/app/services/shared/snackbar.service';
import { TeacherService } from 'src/app/services/shared/teacher.service';

@NgModule({
  declarations: [
    LogoComponent,
    FooterComponent,
    SpinnerComponent,
    NavbarComponent,
    LoadingScreenComponent,
  ],
  imports: [CommonModule, MaterialModule, HttpClientModule],
  exports: [
    MaterialModule,
    LogoComponent,
    FooterComponent,
    SpinnerComponent,
    NavbarComponent,
    LoadingScreenComponent,
  ],
  providers: [SnackbarService, TeacherService],
})
export class SharedModule {}
