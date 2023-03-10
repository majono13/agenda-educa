import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable, map, tap } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuardService {

constructor(private _userService: UserService, private _router: Router) { }

canActivate(
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
): Observable<boolean> {
  return this._userService.isAuthenticated().pipe(
    tap((res) => {
      if (res) this._router.navigateByUrl('/user');
    }),
    map(res => !res),
  );
}
}
