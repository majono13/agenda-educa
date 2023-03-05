import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserLayoutComponent } from 'src/app/layout/user/user-layout/user-layout.component';
import { StudentsComponent } from './students/students-list/students.component';
import { AddStudentComponent } from './students/add-student/add-student.component';

const routes: Routes = [
  {
    path: '',
    component: UserLayoutComponent,
    children: [
      { path: '', redirectTo: 'alunos' },
      { path: 'alunos', component: StudentsComponent },
      {path: 'novo-aluno', component: AddStudentComponent}
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule {}
