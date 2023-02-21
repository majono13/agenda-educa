import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';

//Modulos
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from 'src/app/shared/modules/shared.module';
import { UserLayoutModule } from 'src/app/layout/user/user-layout.module';
import { StudentsComponent } from './students/students.component';

//Interceptor
import { HttpRequestInterceptor } from 'src/app/interceptors/http.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  declarations: [HomeComponent, StudentsComponent],
  imports: [CommonModule, UserRoutingModule, SharedModule, UserLayoutModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpRequestInterceptor,
      multi: true,
    },
  ],
})
export class UserModule {}
