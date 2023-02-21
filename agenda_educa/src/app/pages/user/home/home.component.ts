import { Component, OnInit } from '@angular/core';
import { TeacherService } from 'src/app/services/shared/teacher.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private _teacherService: TeacherService) {}

  ngOnInit(): void {}
}
