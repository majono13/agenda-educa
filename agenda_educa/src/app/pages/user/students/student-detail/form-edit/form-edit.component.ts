import { Location } from '@angular/common';
import { Component, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { School } from 'src/app/models/school.model';
import { Student } from 'src/app/models/student.model';
import { StudentDetail } from 'src/app/models/studentDetail.model';
import { SnackbarService } from 'src/app/services/shared/snackbar.service';
import { TeacherService } from 'src/app/services/shared/teacher.service';
import { SchoolService } from 'src/app/services/user/school.service';
import { StudentsService } from 'src/app/services/user/students.service';

@Component({
  selector: 'app-form-edit',
  templateUrl: './form-edit.component.html',
  styleUrls: ['./form-edit.component.scss']
})
export class FormEditComponent implements OnInit {

  form: FormGroup;
  teacherId: number;
  schools: Observable<School[]>;
  @Input('student') student: StudentDetail;
  @Input('onEdit') onEdit: boolean;

  constructor(private _fb: FormBuilder,
    private _schoolService: SchoolService,
    private _studentsService: StudentsService,
    private _snackBar: SnackbarService,
    private __location: Location) { }

  ngOnInit(): void {
    this.form = this._fb.group({
      name: [this.student?.name, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      class: [this.student?.class, [Validators.required, Validators.maxLength(15)]],
      school: ['', [Validators.required]],
      observations: [this.student?.observations, [Validators.maxLength(1500)]]
    });

    this.getSchools();
  }

  getSchools() {

   this.schools = this._schoolService.getSchools(this.student.teacherId).pipe(map(res => res?.data))
  }

  salve() {
    const student: Student = {
      Name: this.form.value?.name,
      Class: this.form.value?.class,
      SchoolId: this.form.value?.school,
      Observations: this.form.value?.observations,
      TeacherId: this.student.teacherId,
      id: this.student.id,
    };

    console.log(student)

    this._studentsService.editStudent(student)
      .subscribe({
        error: err =>
          this._snackBar.open(err?.error?.message, 3000),
        next: value => {
          this._snackBar.open(`Aluno editado com sucesso!`, 3000)
          this.onEdit = false;
          this.__location.back();
        }
      });
  }
}
