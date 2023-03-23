import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Teacher } from 'src/app/models/teacher.models';
import { TeacherService } from 'src/app/services/shared/teacher.service';
import { DialogComponent } from '../dialog/dialog.component';
import { UserService } from 'src/app/services/auth/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  teacher$: Observable<Teacher>;

  constructor(
    private _teacherService: TeacherService,
    private _userService: UserService,
    private _router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    //chama método que busca os dados do professor a atualiza os subjects
    this._teacherService.getTeacherByUserEmail().subscribe({
      error: err => {
        if(!err?.error?.isSuccess) {
          const dialogRef = this.dialog.open(DialogComponent, {
            data: this._userService.getUserEmail(),
            width: '500px',
            disableClose: true
          })
        };
      }
    });

    //atribui subject atualizado a variável
    this.teacher$ = this._teacherService.getTeacher();
  }

  logout() {
    this._teacherService.logout();
    this._router.navigate(['/login']);
  }
}
