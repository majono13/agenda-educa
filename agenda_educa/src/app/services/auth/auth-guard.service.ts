import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { UserService } from './user.service';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthGuardService {
  constructor(private _router: Router, private _userService: UserService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> {
    return this._userService.isAuthenticated().pipe(
      tap((res) => {
        if (!res) this._router.navigateByUrl('/login');
      })
    );
  }
}
