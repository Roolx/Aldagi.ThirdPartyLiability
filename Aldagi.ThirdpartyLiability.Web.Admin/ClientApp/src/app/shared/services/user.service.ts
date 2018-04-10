import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {
  readonly rootUrl = 'http://localhost:5002';
  constructor(private http: HttpClient) { }

  userAuthentication(userName, password) {

    var data = { userName: userName, password: password };
    return this.http.post(this.rootUrl + '/auth', data);
  }

}