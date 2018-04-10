import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response, RequestOptions } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Injectable()
export class GeneralService {
  readonly rootUrl = 'http://localhost:5001';
  constructor(private http: HttpClient, private router: Router) { }

   public postRequestToApi<T>(data: any, endpoint: string): Observable<T> {
        return this.http.post<T>(this.rootUrl + '/' + endpoint,data);
    }

    public getRequestToApi<T>( endpoint: string): Observable<T> {
        return this.http.get<T>(this.rootUrl + '/' + endpoint );
    }
}
