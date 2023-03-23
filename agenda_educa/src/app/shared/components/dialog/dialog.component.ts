import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Teacher } from 'src/app/models/teacher.models';
import { SnackbarService } from 'src/app/services/shared/snackbar.service';
import { TeacherService } from 'src/app/services/shared/teacher.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

  form: FormGroup

  constructor(public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string,
    private _fb: FormBuilder,
    private _teacherService: TeacherService,
    private _snackBar: SnackbarService,
    private _router: Router) { }

  ngOnInit(): void {
    this.startForm();
  }

  startForm() {
    this.form = this._fb.group({
      firstname: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20),
        ],
      ],
      lastname: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
      ],
      phone: [
        '',
        [
          Validators.required,
          Validators.minLength(11),
          Validators.maxLength(17),
        ],
      ],
    });
  }

  salve() {
    const teacher: Teacher = {
      ...this.form.value,
      email: this.data,
    };
    this._teacherService.createNewTeacher(teacher).subscribe({
      error: (err) => this._snackBar.open(err?.error?.message),
      next: () => {
        this._snackBar.open('Cadastro finalizado!', 3000)
        this.dialogRef.close();
        this._router.navigate(['/user']);
      },
    });
  }

}
