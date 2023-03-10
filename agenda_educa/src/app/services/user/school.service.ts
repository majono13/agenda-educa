import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, take } from 'rxjs';
import { Response } from 'src/app/models/apiResponse.model';
import { School } from 'src/app/models/school.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  private readonly url = `${environment.URL}/school`;

  constructor(private _http: HttpClient) { }

  getSchools(teacherId: number) {
    return this._http.get<Response<School[]>>(`${this.url}/${teacherId}`).pipe(take(1));
  }

  getSchoolById(id: number) {
    return this._http.get<Response<School>>(`${this.url}/get-school/${id}`)
      .pipe(take(1));
  }

  createSchool(school: School) {
    return this._http.post<Response<School>>(this.url, school)
    .pipe(take(1));
  }

  editSchool(school: School) {
    return this._http.put<Response<School>>(this.url, school);
  }
}
