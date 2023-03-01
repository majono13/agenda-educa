import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { Response } from 'src/app/models/apiResponse.model';
import { environment } from 'src/environments/environment';
import { UserService } from '../auth/user.service';
import { Observable, map } from 'rxjs';
import { PagedResponse } from 'src/app/models/pagedBaseResponse.model';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  private readonly url = `${environment.URL}/student`;

  constructor(private _http: HttpClient) {}

  getStudentsByTeacherId(
    page: number,
    pageSize: number,
    filter: string,
    teacherId: number
  ): Observable<Response<PagedResponse<Student[]>>> {
    page++;
    const orderBy = 'Name';

    return this._http.get<Response<any>>(
      `${this.url}/pagination/${teacherId}?Page=${page}&PageSize=${pageSize}&OrderByPropety=${orderBy}&Name=${filter}`
    );
    /*return this._http
      .get<Response<Student[]>>(`${this.url}/get-students/${id}`)
      .pipe(map((res) => res?.data));*/
  }
}
