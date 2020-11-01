import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AuthService } from '../auth.service';



@Injectable()

export class TokenInterceptorService implements HttpInterceptor {

  // We inject a LoginService
  constructor(private authService: AuthService) {}
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
     console.log('INTERCEPTOR');
     const token =this.authService.getTokenStorage();
     let newHeaders = req.headers;
     if (token) {
      newHeaders = newHeaders.set('Authorization', `Bearer ${token}`);
     }
     newHeaders.append('Access-Control-Allow-Origin','*');
     newHeaders.append('Content-Type','application/json');
     // Finally we have to clone our request with our new headers
     // This is required because HttpRequests are immutable
     const authReq = req.clone({headers: newHeaders});
     // Then we return an Observable that will run the request
     // or pass it to the next interceptor if any
     return next.handle(authReq);
  }
}
