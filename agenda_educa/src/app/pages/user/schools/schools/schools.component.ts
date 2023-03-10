import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { School } from 'src/app/models/school.model';
import { SchoolService } from 'src/app/services/user/school.service';

@Component({
  selector: 'app-schools',
  templateUrl: './schools.component.html',
  styleUrls: ['./schools.component.scss']
})
export class SchoolsComponent implements OnInit {

  school: School;
  onEdit: boolean = false;
  showStudentsList: boolean = false;

  constructor(private _route: ActivatedRoute,
    private _router: Router,
    private schoolService:SchoolService,
    private _location: Location) { }

  ngOnInit(): void {
    this._route.paramMap.subscribe(params => {
      this.getSchool(params.get('id'));
      this.showStudentsList = false;
      this.onEdit = false;
    })
  }

  getSchool(id: string) {
    this.schoolService.getSchoolById(Number(id)).subscribe({
      error: err => this._router.navigate(['/page-not-found']),
      next: value => {
        if(value?.isSuccess)
          this.school = value?.data}});
  }

  edit() {
    this.onEdit = !this.onEdit;
    this.showStudentsList = false;
  }

  back() {
    this._location.back();
  }

  studentsList() {
    this.onEdit = false;
    this.showStudentsList = !this.showStudentsList;
  }

  atualize() {
    this.ngOnInit();
  }

}
