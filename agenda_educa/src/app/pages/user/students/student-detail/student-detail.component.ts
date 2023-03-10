import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentDetail } from 'src/app/models/studentDetail.model';
import { SnackbarService } from 'src/app/services/shared/snackbar.service';
import { StudentsService } from 'src/app/services/user/students.service';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styleUrls: ['./student-detail.component.scss']
})
export class StudentDetailComponent implements OnInit {

  student: StudentDetail;
  onEdit: boolean = false;

  constructor(private _route: ActivatedRoute,
    private _router: Router,
    private _studentsService: StudentsService,
    private _loaction: Location,
    private _sanckBar: SnackbarService) { }

  ngOnInit(): void {
    this.getStudentById();
  }

  getStudentById() {
    const id = Number(this._route.snapshot.paramMap.get('id'));

    this._studentsService.getStudentById(id)
    .subscribe({
      error: err => this._router.navigate(['/page-not-found']),
      next: res => {
        if(res?.isSuccess)
          this.student = res?.data;
      }
    });
  }

  edit() {
    this.onEdit = !this.onEdit;
  }

  deleteStudent() {
    this._studentsService.deleteStudent(Number(this.student.id))
    .subscribe({
      error: err => this._sanckBar.open("Falha ao tentar excluir aluno.", 3000),
      next: value => {
        this._sanckBar.open("Aluno excluído com sucesso!");
        this._loaction.back();
      }
    })
  }

  back() {
    this._loaction.back();
  }

}
