import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {
    readonly rootUrl = 'http://localhost:5002';
    constructor(private http: HttpClient, private router: Router) { }

    authenticate(userName, password) {

        var data = { userName: userName, password: password };
        return this.http.post(this.rootUrl + '/auth', data);
    }

    getAccessToken() {
        let token = localStorage.getItem("access_token");
        if (token) {
            return token;
        }
        else {
            this.router.navigate(['/login']);
        }
    }

    logout() {
        localStorage.removeItem('access_token');
        this.router.navigate(['/login']);
      }
}