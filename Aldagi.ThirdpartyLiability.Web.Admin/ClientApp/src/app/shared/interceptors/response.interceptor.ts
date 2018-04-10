
import 'rxjs/add/operator/do';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

 @Injectable()
export class ResponseInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService, private router: Router) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    return next.handle(request).do((event: HttpEvent<any>) => {
    }, (err: any) => {
      if (err instanceof HttpErrorResponse) {
        if (err.status === 401) {
            this.authService.logout();
        }
      }
    });
  }
}