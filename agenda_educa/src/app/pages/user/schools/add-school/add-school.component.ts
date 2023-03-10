import { Location } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { School } from 'src/app/models/school.model';
import { Student } from 'src/app/models/student.model';
import { AddressService } from 'src/app/services/shared/address.service';
import { SnackbarService } from 'src/app/services/shared/snackbar.service';
import { TeacherService } from 'src/app/services/shared/teacher.service';
import { SchoolService } from 'src/app/services/user/school.service';

@Component({
  selector: 'app-add-school',
  templateUrl: './add-school.component.html',
  styleUrls: ['./add-school.component.scss'],
})
export class AddSchoolComponent implements OnInit {
  //Em edição
  @Input('onEdit') onEdit: boolean = false;
  @Input('school') school: School;
  @Output('atualize') atualize = new EventEmitter();

  //Criação de escola
  @ViewChild('schoolForm') schoolForm: NgForm;
  form: FormGroup;
  invalidCep: boolean = false;
  loading: boolean = false;

  constructor(
    private _fb: FormBuilder,
    private _addressService: AddressService,
    private _loaction: Location,
    private _teacherService: TeacherService,
    private _schoolService: SchoolService,
    private _snackBar: SnackbarService
  ) {}

  ngOnInit(): void {

    if(!this.onEdit) {
      this.form = this._fb.group({
        name: [
          '',
          [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(100),
          ],
        ],
        cep: ['', [Validators.required]],
        city: [
          '',
          [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(100),
          ],
        ],
        street: [
          '',
          [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(100),
          ],
        ],
        district: [
          '',
          [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(100),
          ],
        ],
        state: [
          '',
          [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(100),
          ],
        ],
        number: [
          '',
          [
            Validators.required,
            Validators.minLength(1),
            Validators.maxLength(10),
          ],
        ],
      });
    }

    else
      this.startFormOnEdit();

  }

  startFormOnEdit() {
    this.form = this._fb.group({
      name: [
        this.school?.name,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
      cep: [this.school?.cep, [Validators.required]],
      city: [
        this.school?.city,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
      street: [
        this.school?.street,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
      district: [
        this.school?.district,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
      state: [
        this.school?.state,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
      number: [
        this.school?.number,
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(10),
        ],
      ],
    });
  }

  getAddress(data: any) {
    if (this._addressService.getAddress(data)) {
      this._addressService.getAddress(data).subscribe((data: any) => {
        if (data.erro) this.invalidCep = true;
        this.showAddress(data);
      });
    }
  }

  showAddress(data: any) {
    this._addressService.showAddress(data, this.form);
  }

  back() {
    this._loaction.back();
  }

  salve() {
    this.loading = true;
    if(!this.onEdit) {
      const school: School = {
        ...this.form.value,
        teacherId: this._teacherService.getTeacherId(),
        number: this.form.value.number.toString(),
      };

      this._schoolService.createSchool(school).subscribe({
        error: (err) => {
          this._snackBar.open(err?.error?.message, 3000);
          this.loading = false;
        },
        next: (value) => {
          this.loading = false;
          if (value?.isSuccess) {
            this._snackBar.open('Escola criada com sucesso!');
            this.clearForm();
          } else this._snackBar.open(value?.message, 3000);
        }
      });
    }

    else this.salveOnEdite();
  }

  salveOnEdite() {
    const school: School = {
      ...this.form.value,
      number: this.form.value?.number.toString(),
      teacherId: this.school?.teacherId,
      id: this.school?.id
    };

    this._schoolService.editSchool(school).subscribe({
      error: (err) => {
        this._snackBar.open(err?.error?.message, 3000);
        this.loading = false;
      },
      next: (value) => {
        this.loading = false;
        if (value?.isSuccess) {
          this._snackBar.open('Escola editada com sucesso!');
          this.clearForm();
          this.atualize.emit();
        } else this._snackBar.open(value?.message, 3000);
      }
    });
  }

  clearForm() {
    this.schoolForm.resetForm();
  }
}
