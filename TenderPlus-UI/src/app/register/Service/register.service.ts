import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EnvService } from 'src/app/core/env.service';
import { AuthRequest } from 'src/app/core/models/authRequest';
import { login } from 'src/app/models/login.model';
import { register } from 'src/app/models/register.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private authapiUrl = 'api';
  constructor(private _http: HttpClient,
    private _env: EnvService) { }

    registerUser(register:login): Observable<any> {
      // var authReqest = new AuthRequest();
      // authReqest.username=username;
      // authReqest.password=password;
      return this._http.post(`${this._env.localBaseUrl + this.authapiUrl}` + '/users',register )
        .pipe(
          //tap(data => console.log(JSON.stringify(data))),
          catchError(this.handleError)
        );
    }
    postadminuser(register:login): Observable<any> {
      // var authReqest = new AuthRequest();
      // authReqest.username=username;
      // authReqest.password=password;
      return this._http.post(`${this._env.localBaseUrl + this.authapiUrl}` + '/users/postadminuser',register )
        .pipe(
          //tap(data => console.log(JSON.stringify(data))),
          catchError(this.handleError)
        );
    }
    getUserByID(username:string): Observable<any> {
      const params = new HttpParams()
      .set('user', username);

      return this._http.get(`${this._env.localBaseUrl + this.authapiUrl}` + '/users/getuserbyid', { params } )
        .pipe(
          //tap(data => console.log(JSON.stringify(data))),
          catchError(this.handleError)
        );
    }
    private handleError(error: any): Promise<any> {
      console.error('Error: unable to parse response', error);
      return Promise.reject(error.message || error);
    }
}
