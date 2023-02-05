import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Teacher } from 'src/app/models/teacher.models';
import { environment } from 'src/environments/environment';
import { Response } from 'src/app/models/apiResponse.model';

@Injectable({
  providedIn: 'root',
})
export class TeacherService {
  private readonly url = `${environment.URL}/teacher`;
  constructor(private _htpp: HttpClient) {}

  createNewTeacher(teacher: Teacher): Observable<Response<Teacher>> {
    return this._htpp.post<Response<Teacher>>(this.url, teacher).pipe(take(1));
  }
}
