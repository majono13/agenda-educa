import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { StudentsService } from 'src/app/services/user/students.service';
import { TeacherService } from 'src/app/services/shared/teacher.service';
import { PaginatorHelper } from 'src/app/helpers/paginator.helper';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss'],
})
export class StudentsComponent implements OnInit, AfterViewInit {
  //Paginação
  @ViewChild(MatPaginator) paginator: MatPaginator;
  paginatorHelper: typeof PaginatorHelper = PaginatorHelper;
  totalItems: number;

  dataSource: MatTableDataSource<Student> = new MatTableDataSource<Student>();
  displayedColumns = ['name', 'school', 'class'];
  filter: string = '';
  teacherId: number = null;

  //Pesquisa
  searchForm: FormGroup;
  loading: boolean = true;
  dataFound: boolean = null;

  constructor(
    private _studentsService: StudentsService,
    private _teacherService: TeacherService,
    private _fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.getStudentsByTeacherId();

    this.searchForm = this._fb.group({
      search: [''],
    });

    this.searchForm.controls['search'].valueChanges
      .pipe(debounceTime(500), distinctUntilChanged())
      .subscribe((value) => {
        this.filter = value;
        if (value.length >= 3 || value.length == 0) {
          if (this.paginator) this.paginator.pageIndex = 0;

          this.loadList(this.teacherId);
        }
      });
  }

  ngAfterViewInit(): void {
    // Captura evento de mudança na paginação
    this.paginator.page.subscribe((value: string) => {
      console.log(value);
      this.loadList(this.teacherId);
    });
  }

  getStudentsByTeacherId() {
    //Pega dados do professor contidos no subject e passa para
    //o serviço enviar a requisição
    this._teacherService.getTeacher().subscribe((res) => {
      if (res) {
        this.teacherId = res?.id;
        this.loadList(res?.id);
      }
    });
  }

  loadList(teacherId: number) {
    this.loading = true;
    this._studentsService
      .getStudentsByTeacherId(
        this.paginator?.pageIndex ?? 0,
        this.paginator?.pageSize ?? Number(this.paginatorHelper?.PageSize),
        this.filter,
        teacherId
      )
      .toPromise()
      .then((res) => {
        this.loading = false;
        if (res?.isSuccess) {
          this.dataSource.data = res?.data?.data;
          this.totalItems = res?.data?.totalRegisters;

          if (this.filter.length > 3 || res?.data?.data.length <= 0)
            this.dataFound = false;
          else this.dataFound = true;
        }
      });
  }
}
