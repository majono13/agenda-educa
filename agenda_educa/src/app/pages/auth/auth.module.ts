import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modulos
import { AuthRoutingModule } from './auth-routing.module';
import { SharedModule } from 'src/app/shared/modules/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';

//Componentes
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { StepOneComponent } from './register/step-one/step-one.component';
import { StepTwoComponent } from './register/step-two/step-two.component';
import { HttpRequestInterceptor } from 'src/app/interceptors/http.interceptor';

@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent,
    ResetPasswordComponent,
    StepOneComponent,
    StepTwoComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    NgxMaskModule,
  ],
})
export class AuthModule {
  static forRoot(): ModuleWithProviders<any> {
    return {
      ngModule: AuthModule,
      providers: [HttpRequestInterceptor],
    };
  }
}
