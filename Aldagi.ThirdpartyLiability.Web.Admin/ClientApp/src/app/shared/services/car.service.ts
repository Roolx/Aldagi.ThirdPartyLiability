import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class CarService {
  readonly rootUrl = 'http://localhost:5001';
  constructor(private http: HttpClient) { }

  getManufacturers() {
    return this.http.get(this.rootUrl + '/cars/manufacturers');
  }

  getCars(manufacturerId:number){
    return this.http.get(this.rootUrl + `/cars/${manufacturerId}`);
  }
}