import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SchoolModalComponent } from 'src/app/pages/user/schools/school-modal/school-modal.component';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss'],
})
export class SidenavComponent implements OnInit {
  screenWidth: number;
  showColumn: string = '';
  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
    this.screenWidth = window.innerWidth;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.screenWidth = window.innerWidth;
  }

  show(column: string) {
    if (column === this.showColumn) this.showColumn = '';
    else this.showColumn = column;
  }

  openSchools() {
    this.dialog.open(SchoolModalComponent);
  }
}
