import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { UserService } from 'src/app/services/auth/user.service';
import { SnackbarService } from 'src/app/services/shared/snackbar.service';
import { ValidatorPassword } from 'src/app/validators/password-validator';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss'],
})
export class ResetPasswordComponent implements OnInit {
  emailValid: boolean = null;
  loading: boolean = false;
  form: FormGroup;

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _router: Router,
    private _snackbar: SnackbarService
  ) {}

  ngOnInit(): void {
    this.form = this._fb.group({
      email: ['', [Validators.email, Validators.required]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(20),
        ],
      ],
      rePassword: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(20),
          ValidatorPassword.Equal,
        ],
      ],
    });

    this.form.controls['email'].valueChanges
      .pipe(debounceTime(500), distinctUntilChanged())
      .subscribe((value) => {
        this.emailValid = null;
        this.loading = false;
        if (!this.form.controls['email']?.errors?.['email'])
          this.verifyEmail(value);
      });
  }

  verifyEmail(email: string) {
    this.loading = true;
    this._userService
      .verifyIfEmailExists(email)
      .toPromise()
      .then((res) => {
        this.loading = false;

        if (res) this.emailValid = true;
        else this.emailValid = false;
      });
  }

  confirm() {
    this._userService
      .editPassword({
        email: this.form.value.email,
        password: this.form.value.password,
      })
      .subscribe({
        error: (err) => this._snackbar.open(err?.error?.message, 3000),
        next: (res) => {
          this._snackbar.open('Sua senha editada com sucesso!');
          this._router.navigate(['/login']);
        },
      });
  }
}
