import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class FormService {
  constructor() {}

  clearFields(form: NgForm) {
    form.resetForm();
  }
}
