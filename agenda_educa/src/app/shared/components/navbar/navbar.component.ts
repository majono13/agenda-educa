import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Teacher } from 'src/app/models/teacher.models';
import { TeacherService } from 'src/app/services/shared/teacher.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  teacher$: Observable<Teacher>;

  constructor(
    private _teacherService: TeacherService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this._teacherService.getTeacherByUserEmail().subscribe();
    this.teacher$ = this._teacherService.getTeacher();
  }

  logout() {
    this._teacherService.logout();
    this._router.navigate(['/login']);
  }
}
