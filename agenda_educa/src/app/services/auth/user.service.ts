import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  BehaviorSubject,
  Observable,
  catchError,
  map,
  of,
  take,
  tap,
} from 'rxjs';
import { User } from 'src/app/models/user.model';
import { environment } from 'src/environments/environment';
import { TokenService } from './token.service';
import { Response } from 'src/app/models/apiResponse.model';
import { LoginResponse } from 'src/app/models/loginResponse.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly url = `${environment.URL}/user`;
  private _subUserEmail$: BehaviorSubject<string> = new BehaviorSubject<string>(
    null
  );
  private _subLoggedIn$: BehaviorSubject<boolean> =
    new BehaviorSubject<boolean>(false);

  constructor(private _http: HttpClient, private _tokenService: TokenService) {}

  /** Método para fazer login **/
  login(user: User): Observable<Response<LoginResponse>> {
    return this._http
      .post<Response<LoginResponse>>(`${this.url}/login`, user)
      .pipe(
        take(1),
        tap((res) => {
          this._tokenService.setToken(res.data.token.access_token),
            this._subLoggedIn$.next(true),
            this._subUserEmail$.next(res.data.email);
        })
      );
  }

  /** Verifica se usuário tem token setado e busca usuário pelo token **/
  isAuthenticated(): Observable<boolean> {
    const token = this._tokenService.getToken();

    if (token !== null && !this._subLoggedIn$.value)
      return this.checkTokenValidation(token);

    return this._subLoggedIn$.asObservable();
  }

  /** Verifica se o token setado é válido e atualiza subjetcs
   * caso o token seja inválido realiza o logout
   * **/
  checkTokenValidation(token: string): Observable<boolean> {
    return this._http.get<any>(`${this.url}/token/${token}`).pipe(
      tap((res) => this.updateSubjectsLoggedInAndEmail(res?.data)),
      map((res) => (res ? true : false)),
      catchError((err) => {
        this.logout();
        return of(false);
      })
    );
  }

  /** Métodos get para atributos privados **/
  getSubLoggedIn$(): Observable<boolean> {
    return this._subLoggedIn$.asObservable();
  }
  getSubUserEmail$(): Observable<string> {
    return this._subUserEmail$.asObservable();
  }

  /** Método privado para atualizar informações de usuário logado **/
  private updateSubjectsLoggedInAndEmail(email: string) {
    if (email) {
      this._subUserEmail$.next(email);
      this._subLoggedIn$.next(true);
    }
  }

  /** Método para logout **/
  logout() {
    this._tokenService.removeToken();
    this._subLoggedIn$.next(false);
    this._subUserEmail$.next(null);
  }
}
