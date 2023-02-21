import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { Response } from 'src/app/models/apiResponse.model';
import { environment } from 'src/environments/environment';
import { UserService } from '../auth/user.service';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  private readonly url = `${environment.URL}/student`;

  constructor(private _http: HttpClient) {}

  getStudentsByTeacherId(id: number) {
    return this._http
      .get<Response<Student[]>>(`${this.url}/get-students/${id}`)
      .pipe(map((res) => res?.data));
  }
}
