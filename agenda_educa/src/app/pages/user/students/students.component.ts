import { Component, OnInit } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Student } from 'src/app/models/student.model';
import { StudentsService } from 'src/app/services/user/students.service';
import { TeacherService } from 'src/app/services/shared/teacher.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss'],
})
export class StudentsComponent implements OnInit {
  dataSource: Observable<Student[]>;
  displayedColumns = ['name', 'school', 'class'];

  constructor(
    private _studentsService: StudentsService,
    private _teacherService: TeacherService
  ) {}

  ngOnInit(): void {
    this.getStudentsByTeacherId();
  }

  getStudentsByTeacherId() {
    this._teacherService.getTeacher().subscribe((res) => {
      if (res) {
        this.dataSource = this._studentsService.getStudentsByTeacherId(res?.id);
        this._studentsService
          .getStudentsByTeacherId(res?.id)
          .subscribe((res) => console.log(res));
      }
    });
  }
}
