import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EnvService } from '../core/env.service';
import { AuthRequest } from '../core/models/authRequest';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  private authapiUrl = 'api';
  constructor(private _http: HttpClient,
    private _env: EnvService) { }

  makepayement(username: string, password: string): Observable<any> {
    var authReqest = new AuthRequest();
    authReqest.username=username;
    authReqest.password=password;
    return this._http.post(`${this._env.localBaseUrl + this.authapiUrl}` + '/payment', authReqest)
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
