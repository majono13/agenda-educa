import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, of, take, tap } from 'rxjs';
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
  private _UserEmail: string = '';
  private _subLoggedIn$: BehaviorSubject<boolean> =
    new BehaviorSubject<boolean>(false);

  constructor(private _http: HttpClient, private _tokenService: TokenService) {}

  /** Método para buscar usuário por email **/
  verifyIfEmailExists(email: string): Observable<Boolean> {
    return this._http.get<Response<User>>(`${this.url}/${email}`).pipe(
      map((res) => {
        if (res?.data?.email) return true;
        else return false;
      })
    );
  }

  /** Método para editar senha **/
  editPassword(user: User): Observable<Response<User>> {
    return this._http
      .put<Response<User>>(`${this.url}/edit`, user)
      .pipe(take(1));
  }

  /** Método para criar novo usuário **/
  createNewUser(user: User): Observable<Response<User>> {
    return this._http.post<Response<User>>(`${this.url}`, user).pipe(take(1));
  }

  /** Método para fazer login **/
  login(user: User): Observable<Response<LoginResponse>> {
    return this._http
      .post<Response<LoginResponse>>(`${this.url}/login`, user)
      .pipe(
        take(1),
        tap((res) => {
          this._tokenService.setToken(res.data.token.access_token),
            this._subLoggedIn$.next(true),
            (this._UserEmail = res.data.email);
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
      tap((res) => this.updateSubjectLoggedInAndEmail(res?.data)),
      map((res) => (res ? true : false))
      /*catchError((err) => {
        this.logout();
        return of(false);
      })*/
    );
  }

  /** Métodos get para atributos privados **/
  getSubLoggedIn$(): Observable<boolean> {
    return this._subLoggedIn$.asObservable();
  }
  getUserEmail(): string {
    return this._UserEmail;
  }

  /** Método privado para atualizar informações de usuário logado **/
  private updateSubjectLoggedInAndEmail(email: string) {
    if (email) {
      this._UserEmail = email;
      this._subLoggedIn$.next(true);
    }
  }

  /** Método para logout **/
  logout() {
    this._tokenService.removeToken();
    this._subLoggedIn$.next(false);
    this._UserEmail = null;
  }
}
