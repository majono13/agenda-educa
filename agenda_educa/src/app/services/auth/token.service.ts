import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private readonly key = 'token';

  constructor() {}

  setToken(token: string) {
    localStorage.setItem(this.key, token);
  }

  getToken(): string {
    return localStorage.getItem(this.key);
  }

  removeToken() {
    localStorage.removeItem(this.key);
  }
}
