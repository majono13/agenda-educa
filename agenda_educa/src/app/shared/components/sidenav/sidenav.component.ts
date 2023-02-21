import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss'],
})
export class SidenavComponent implements OnInit {
  screenWidth: number;
  showColumn: string = '';
  constructor() {}

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
}
