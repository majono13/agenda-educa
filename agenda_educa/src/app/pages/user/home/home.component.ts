import { Component, OnInit } from '@angular/core';
import { StudentsService } from 'src/app/services/user/students.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private _studentService: StudentsService) {}

  ngOnInit(): void {
    this._studentService.getAllStudents().subscribe((res) => console.log(res));
  }
}
