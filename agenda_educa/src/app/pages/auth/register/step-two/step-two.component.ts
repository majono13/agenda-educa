import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-step-two',
  templateUrl: './step-two.component.html',
  styleUrls: ['./step-two.component.scss'],
})
export class StepTwoComponent implements OnInit {
  @Input('step2Form') step2Form: FormGroup;
  @Input('email') email: string;
  constructor() {}

  ngOnInit(): void {}
}
