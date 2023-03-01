import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-search-input',
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.scss'],
})
export class SearchInputComponent implements OnInit {
  @Input('message') message: string = 'Faça sua pesquisa';
  @Input('loading') loading: boolean = false;
  @Input('searchForm') searchForm: FormGroup;

  constructor() {}

  ngOnInit(): void {}
}
