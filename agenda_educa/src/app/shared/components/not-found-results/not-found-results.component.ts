import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-not-found-results',
  templateUrl: './not-found-results.component.html',
  styleUrls: ['./not-found-results.component.scss'],
})
export class NotFoundResultsComponent implements OnInit {
  @Input('message') message: string =
    'Não foram encontrados dados correspondentes';
  constructor() {}

  ngOnInit(): void {}
}
