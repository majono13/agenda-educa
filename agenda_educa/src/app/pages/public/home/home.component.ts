import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  animateSection2: boolean = false;

  constructor(private _router: Router) { }

  ngOnInit(): void {
  }

  register() {
    this._router.navigate(['/login/cadastro']);
  }

  login() {
    this._router.navigate(['/login']);
  }


}
