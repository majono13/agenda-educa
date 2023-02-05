import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-step-one',
  templateUrl: './step-one.component.html',
  styleUrls: ['./step-one.component.scss'],
})
export class StepOneComponent implements OnInit {
  @Input('step1Form') step1Form: FormGroup;

  constructor(private _fb: FormBuilder) {}

  ngOnInit(): void {}
}
