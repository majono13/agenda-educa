import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modulos
import { AuthRoutingModule } from './auth-routing.module';
import { SharedModule } from 'src/app/shared/modules/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

//Componentes
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

@NgModule({
  declarations: [RegisterComponent, LoginComponent, ResetPasswordComponent],
  imports: [CommonModule, AuthRoutingModule, SharedModule, ReactiveFormsModule],
})
export class AuthModule {}
