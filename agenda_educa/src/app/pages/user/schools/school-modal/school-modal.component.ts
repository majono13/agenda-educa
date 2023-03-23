import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { School } from 'src/app/models/school.model';
import { TeacherService } from 'src/app/services/shared/teacher.service';
import { SchoolService } from 'src/app/services/user/school.service';

@Component({
  selector: 'app-school-modal',
  templateUrl: './school-modal.component.html',
  styleUrls: ['./school-modal.component.scss']
})
export class SchoolModalComponent implements OnInit {

  schools: Observable<School[]>;
  form: FormGroup = this._fb.group({
    school: ['']
  });

  constructor(private _fb: FormBuilder,
    private _schoolsService: SchoolService,
    private _teacherService: TeacherService,
    private dialog: MatDialogRef<SchoolModalComponent>,
    private _router: Router) { }

  ngOnInit(): void {
    this.getSchools();
  }

  private getSchools() {
    this._teacherService.getTeacherId()
    this.schools = this._schoolsService.getSchools(this._teacherService.getTeacherId())
      .pipe(map(res => res.data));
  }

  close() {
    this.dialog.close();
  }

  confirm() {
   const url = this.configUrl();
    this._router.navigate([`/user/escolas/${this.form.value.school?.id}/${url}`]);
    this.close();
  }

  private configUrl(): string {
    const school = this.form.value.school;

   let url = school?.school.normalize('NFD').replace(/[\u0300-\u036f]/g, "");
   url = url.replace(/ /g, '-').toLowerCase();

    return url;
  }

}
