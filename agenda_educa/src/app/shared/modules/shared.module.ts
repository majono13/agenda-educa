import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Módulos
import { MaterialModule } from './material.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

//Componentes
import { LogoComponent } from '../components/logo/logo.component';
import { FooterComponent } from '../components/footer/footer.component';
import { SpinnerComponent } from '../components/spinner/spinner.component';
import { NavbarComponent } from '../components/navbar/navbar.component';
import { LoadingScreenComponent } from '../components/loading-screen/loading-screen.component';
import { SearchInputComponent } from '../components/search-input/search-input.component';
import { NotFoundResultsComponent } from '../components/not-found-results/not-found-results.component';
import { SchoolModalComponent } from 'src/app/pages/user/schools/school-modal/school-modal.component';
import { PageNotFoundComponent } from '../components/page-not-found/page-not-found.component';
import { StepTwoComponent } from 'src/app/pages/auth/register/step-two/step-two.component';
import { DialogComponent } from '../components/dialog/dialog.component';

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
    SearchInputComponent,
    NotFoundResultsComponent,
    SchoolModalComponent,
    PageNotFoundComponent,
    StepTwoComponent,
    DialogComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  exports: [
    MaterialModule,
    LogoComponent,
    FooterComponent,
    SpinnerComponent,
    NavbarComponent,
    LoadingScreenComponent,
    SearchInputComponent,
    ReactiveFormsModule,
    NotFoundResultsComponent,
    SchoolModalComponent,
    PageNotFoundComponent,
    StepTwoComponent,
    DialogComponent,
  ],
  providers: [SnackbarService, TeacherService],
})
export class SharedModule {}
