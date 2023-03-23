import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { Response } from 'src/app/models/apiResponse.model';
import { environment } from 'src/environments/environment';
import { Observable, delay, map, take } from 'rxjs';
import { PagedResponse } from 'src/app/models/pagedBaseResponse.model';
import { StudentDetail } from 'src/app/models/studentDetail.model';

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
    teacherId: number,
    schoolId: number
  ): Observable<Response<PagedResponse<StudentDetail[]>>> {
    page++;
    const orderBy = 'Name';
    if(filter.length >= 3) page = 1

    return this._http
      .get<Response<any>>(
        `${this.url}/pagination/${teacherId}?Page=${page}&PageSize=${pageSize}&OrderByPropety=${orderBy}&Name=${filter}&SchoolId=${schoolId}`
      )
      .pipe(delay(1000));
  }

  createStudent(student: Student) {
   return this._http.post<Response<Student>>(this.url, student)
   .pipe(take(1));
  }

  getStudentById(id: number) {
    return this._http.get<Response<StudentDetail>>(`${this.url}/get-student/${id}`);
  }

  editStudent(student: Student) {
    return this._http.put<Response<StudentDetail>>(`${this.url}`, student);
  }

  deleteStudent(id: number) {
    return this._http.delete<Response<StudentDetail>>(`${this.url}/${id}`).pipe(take(1));
  }

  formatBirthday(date: Date) {
    const dateBirthday = new Date(date);

    if(dateBirthday.getMonth() < 9)
    return `${dateBirthday.getDate()}/0${dateBirthday.getMonth() + 1}/${dateBirthday.getFullYear()}`;

    return `${dateBirthday.getDate()}/${dateBirthday.getMonth() + 1}/${dateBirthday.getFullYear()}`;

  }
}
