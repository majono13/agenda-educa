import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Observable, map } from 'rxjs';
import { School } from 'src/app/models/school.model';
import { Student } from 'src/app/models/student.model';
import { SnackbarService } from 'src/app/services/shared/snackbar.service';
import { TeacherService } from 'src/app/services/shared/teacher.service';
import { SchoolService } from 'src/app/services/user/school.service';
import { StudentsService } from 'src/app/services/user/students.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss']
})
export class AddStudentComponent implements OnInit {

  private teacherId: number;
  schools: Observable<School[]>;
  form: FormGroup;
  @ViewChild('formView') formView: NgForm;
  loading: boolean = false;

  constructor(private _teacherService: TeacherService,
    private _schoolService: SchoolService,
    private _studentService: StudentsService,
    private _fb: FormBuilder,
    private _snackBar: SnackbarService) { }

  ngOnInit(): void {
    this.getSchools();

    this.form = this._fb.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      class: ['', [Validators.required, Validators.maxLength(15)]],
      school: ['', [Validators.required]]
    });
  }

  getSchools() {
    this._teacherService.getTeacher().subscribe(res => {
      if(res){
        this.teacherId = res?.id;
        this.schools = this._schoolService.getSchools(res?.id).pipe(map(res => res?.data))
      }
    });
  }

  salve() {
    this.loading = true;
    const student: Student = {
      Name: this.form.value?.name,
      Class: this.form.value?.class,
      SchoolId: this.form.value?.school,
      TeacherId: this.teacherId
    };

    this._studentService.createStudent(student)
    .subscribe({
      error: err => {
        this.loading = false;
        this._snackBar.open(err?.error?.message, 3500);
      },
      next: value => {
        this.loading = false;
        this._snackBar.open("Aluno criado com sucesso!", 3000);
        this.cancel()
      }
    });
  }

  cancel() {
    this.formView.resetForm();
  }

}
