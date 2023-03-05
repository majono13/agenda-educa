import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Response } from 'src/app/models/apiResponse.model';
import { School } from 'src/app/models/school.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  private readonly url = `${environment.URL}/school`

  constructor(private _http: HttpClient) { }

  getSchools(teacherId: number) {
    return this._http.get<Response<School[]>>(`${this.url}/${teacherId}`);
  }
}
