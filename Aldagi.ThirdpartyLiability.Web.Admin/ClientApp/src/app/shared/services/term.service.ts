import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class TermService {
  readonly rootUrl = 'http://localhost:5001';
  constructor(private http: HttpClient) { }

  getTerms() {
    return this.http.get(this.rootUrl + '/liabilities');
  }

  getTerm(termId:number){
    return this.http.get(this.rootUrl + `/liabilities/${termId}`);
  }

  getStatuses(){
      return this.http.get(this.rootUrl + '/liabilities/statuses');
  }
}