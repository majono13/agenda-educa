import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modulos
import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from 'src/app/shared/modules/shared.module';
import { UserLayoutModule } from 'src/app/layout/user/user-layout.module';
import { StudentsComponent } from './students/students-list/students.component';

//Interceptor
import { HttpRequestInterceptor } from 'src/app/interceptors/http.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AddStudentComponent } from './students/add-student/add-student.component';
import { StudentDetailComponent } from './students/student-detail/student-detail.component';

@NgModule({
  declarations: [StudentsComponent, AddStudentComponent, StudentDetailComponent],
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
