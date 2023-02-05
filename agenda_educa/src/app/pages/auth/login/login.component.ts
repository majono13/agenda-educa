import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/auth/user.service';
import { SnackbarService } from 'src/app/services/shared/snackbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading: boolean = false;

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _snackbar: SnackbarService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this._fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.maxLength(20),
          Validators.minLength(6),
        ],
      ],
    });
  }

  login() {
    this.loading = true;
    this._userService.login(this.loginForm.value).subscribe({
      error: (err) => {
        this.loading = false;
        this._snackbar.open(err?.error?.message, 3000);
      },
      next: (value) => {
        this.loading = false;
        this._router.navigate(['/user']);
      },
    });
  }
}
