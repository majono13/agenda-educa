import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, take, tap } from 'rxjs';
import { Teacher } from 'src/app/models/teacher.models';
import { environment } from 'src/environments/environment';
import { Response } from 'src/app/models/apiResponse.model';
import { UserService } from '../auth/user.service';

@Injectable({
  providedIn: 'root',
})
export class TeacherService {
  private readonly url = `${environment.URL}/teacher`;
  private _subjTeacher$: BehaviorSubject<Teacher> =
    new BehaviorSubject<Teacher>(null);
  private _teacherId: number = null;

  constructor(private _htpp: HttpClient, private _userService: UserService) {}

  /** Método para criar novo professor **/
  createNewTeacher(teacher: Teacher): Observable<Response<Teacher>> {
    return this._htpp.post<Response<Teacher>>(this.url, teacher).pipe(take(1));
  }

  /** Método para buscar professor pelo e-mail de usuário **/
  getTeacherByUserEmail() {
    let teacherEmail = this.getTeacherEmail();

    return this._htpp
      .get<Response<Teacher>>(
        `${this.url}/get-teacher-by-email/${teacherEmail}`
      )
      .pipe(
        take(1),
        tap((res) => {
          res ? this._subjTeacher$.next(res?.data) : null;
          res ? (this._teacherId = res?.data?.id) : null;
        })
      );
  }

  /** Métodos get para acesso de variáveis privadas**/
  getTeacher() {
    return this._subjTeacher$;
  }

  getTeacherId() {
    return this._teacherId;
  }

  /** Método para realizar logout **/
  logout() {
    this._userService.logout();
    this._subjTeacher$.next(null);
  }

  private getTeacherEmail() {
    return this._userService.getUserEmail();
  }
}
