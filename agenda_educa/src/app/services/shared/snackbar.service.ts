import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class SnackbarService {
  constructor(private _snackBar: MatSnackBar) {}

  open(message: string, duration: number = 2000) {
    if (message == null || message == undefined || message.length == 0)
      message = 'Algo deu errado, tente novamente mais tarde';

    this._snackBar.open(message, 'Ok', { duration: duration });
  }
}
