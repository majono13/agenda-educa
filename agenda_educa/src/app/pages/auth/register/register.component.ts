import { Location } from '@angular/common';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Teacher } from 'src/app/models/teacher.models';
import { UserService } from 'src/app/services/auth/user.service';
import { SnackbarService } from 'src/app/services/shared/snackbar.service';
import { TeacherService } from 'src/app/services/shared/teacher.service';
import { ValidatorPassword } from 'src/app/validators/password-validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  //encapsulation: ViewEncapsulation,
})
export class RegisterComponent implements OnInit {
  step1Form: FormGroup; //form passo 1
  step2Form: FormGroup; //form passo 2
  nextStep: boolean = false; //contra exibição do formulário a ser exibido
  loading: boolean = false; //controla exibição do spinner

  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _teacherService: TeacherService,
    private _snackbar: SnackbarService,
    private _router: Router,
    private _location: Location
  ) {}

  ngOnInit(): void {
    this.initiatesFormStep1();
    this.initiatesFormStep2();
  }

  // Inicia formulário do primeiro passo
  initiatesFormStep1() {
    this.step1Form = this._fb.group({
      email: ['', [Validators.required, Validators.email]],
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
  }

  // Inicia formulário do segundo passo
  initiatesFormStep2() {
    this.step2Form = this._fb.group({
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

  //Cria o usuário
  createUser() {
    this.loading = true;
    this._userService
      .createNewUser({
        email: this.step1Form.value.email,
        password: this.step1Form.value.password,
      })
      .subscribe({
        error: (err) => {
          this.loading = false;
          this._snackbar.open(err?.error?.message);
        },
        next: () => {
          this.loading = false;
          this.nextStep = !this.nextStep;
        },
      });
  }

  //Cria o professor vinculado ao emaildo usuário
  createTeacher() {
    this.loading = true;

    const teacher: Teacher = {
      ...this.step2Form.value,
      email: this.step1Form.value.email,
    };
    this._teacherService.createNewTeacher(teacher).subscribe({
      error: (err) => {
        this.loading = false;
        this._snackbar.open(err?.error?.message);
      },
      next: () => {
        this._snackbar.open('Usuário criado com sucesso!');
        this._router.navigate(['/login']);
      },
    });
  }

  back() {
    this._location.back();
  }
}
