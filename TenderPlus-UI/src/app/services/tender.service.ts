import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EnvService } from '../core/env.service';
import { registerUsers } from '../models/register.model';
import { Tender } from '../models/tender.model';

@Injectable({
  providedIn: 'root'
})
export class TenderService {
  private authapiUrl = 'api';
  constructor(private _http: HttpClient,
    private _env: EnvService) { }

    createTender(tender:Tender): Observable<any> {

      return this._http.post(`${this._env.localBaseUrl + this.authapiUrl}` + '/Tenders/create',tender)
        .pipe(
          catchError(this.handleError)
        );
    }
    UpdateTender(tender:Tender): Observable<any> {

      return this._http.post(`${this._env.localBaseUrl + this.authapiUrl}` + '/Tenders/update',tender)
        .pipe(
          catchError(this.handleError)
        );
    }
    DeleteTender(tender:Tender): Observable<any> {
      const params = new HttpParams()
      .set('id', tender.id.toString());

      return this._http.delete(`${this._env.localBaseUrl + this.authapiUrl}` + '/Tenders/'+tender.id  )
        .pipe(
          catchError(this.handleError)
        );
    }
    GetTenders(): Observable<any> {

      return this._http.get(`${this._env.localBaseUrl + this.authapiUrl}` + '/Tenders')
        .pipe(
          catchError(this.handleError)
        );
    }

    GetRegisteredUsers(tenderid:Number): Observable<any> {
      const params = new HttpParams()
      .set('tenderid', tenderid.toString());
      return this._http.get(`${this._env.localBaseUrl + this.authapiUrl}` + '/Tenders/getregisters/'+tenderid )
        .pipe(
          catchError(this.handleError)
        );
    }
    CreateTenderUsers(request:registerUsers): Observable<any> {
      // const params = new HttpParams()
      // .set('tenderid', tenderid.toString())
      // .set('userid', userid.toString());
      return this._http.post(`${this._env.localBaseUrl + this.authapiUrl}` + '/Tenders/tenderregister',request)
        .pipe(
          catchError(this.handleError)
        );
    }
    private handleError(error: any): Promise<any> {
      console.error('Error: unable to parse response', error);
      return Promise.reject(error.message || error);
    }
}
