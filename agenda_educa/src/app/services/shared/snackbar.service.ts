import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class SnackbarService {
  constructor(private _snackBar: MatSnackBar) {}

  open(message: string, duration: number = 2000) {
    this._snackBar.open(message, 'Ok', { duration: duration });
  }
}
