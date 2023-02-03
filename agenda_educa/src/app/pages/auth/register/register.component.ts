import { Location } from '@angular/common';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  //encapsulation: ViewEncapsulation,
})
export class RegisterComponent implements OnInit {
  constructor(private _location: Location) {}

  ngOnInit(): void {}

  back() {
    this._location.back();
  }
}
