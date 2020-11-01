import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthRequest, AuthResponse } from './models/authRequest';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { EnvService } from './env.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  helper = new JwtHelperService();
  // username: string;
  // password: string;
  private authapiUrl = 'Logins';

  constructor(private _http: HttpClient,
    private _env: EnvService) { }

  isLoggedIn() {
    return !!localStorage.getItem("token");
  }
  getTokenStorage(): string {
    return localStorage.getItem("token");
  }

  isTokenExpired() {
    return this.helper.isTokenExpired(this.getTokenStorage());
  }

  deleteToken(): void {
    localStorage.removeItem("token");
  }
  getToken(username: string, password: string) {
    var authReqest = new AuthRequest(username, password);
    return new Promise(resolve => {
      // this._env.baseUrl="https://10.100.8.74:9090/";
      this._http.post(`${this._env.localBaseUrl + this.authapiUrl}` + '/authenticate', authReqest).subscribe(data => {
        resolve(this.mapToken(data));
      });
    }).catch(this.handleError);;

  }

  private handleError(error: any): Promise<any> {
    console.error('Error: unable to parse response', error);
    return Promise.reject(error.message || error);
  }

  mapToken(data: any): any {
    const response = new AuthResponse();
    response.id = data.id;
    response.token = data.token;
    response.hkey1 = data.hkey1;
    localStorage.setItem("token", data.token);
    return response;
  }

}
