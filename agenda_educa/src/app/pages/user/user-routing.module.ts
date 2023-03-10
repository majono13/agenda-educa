import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserLayoutComponent } from 'src/app/layout/user/user-layout/user-layout.component';
import { StudentsComponent } from './students/students-list/students.component';
import { AddStudentComponent } from './students/add-student/add-student.component';
import { StudentDetailComponent } from './students/student-detail/student-detail.component';
import { FormEditComponent } from './students/student-detail/form-edit/form-edit.component';
import { SchoolsComponent } from './schools/schools/schools.component';
import { AddSchoolComponent } from './schools/add-school/add-school.component';

const routes: Routes = [
  {
    path: '',
    component: UserLayoutComponent,
    children: [
      { path: '', redirectTo: 'alunos' },
      { path: 'alunos', component: StudentsComponent },
      {path: 'novo-aluno', component: AddStudentComponent},
      {path:'aluno/:id', component: StudentDetailComponent},
      {path:'escolas/:id/:school', component: SchoolsComponent},
      {path:'nova-escola', component: AddSchoolComponent}
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule {}
