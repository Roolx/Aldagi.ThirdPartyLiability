import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class ClientService {
  readonly rootUrl = 'http://localhost:5001';
  constructor(private http: HttpClient) { }

  getClients() {
    return this.http.get(this.rootUrl + '/clients');
  }

  getClientDetails(client: any) {
    return this.http.get(this.rootUrl + `/clients/${client.clientId}`);
  }

  getTermDetails(client: any) {
    return this.http.get(this.rootUrl + `/clients/${client.clientId}/liability/details`);
  }


  registerClient(client:any){
    return this.http.post(this.rootUrl + `/clients/register`,client);
  }

  updateClientTerm(client: any, termId: number){
    return this.http.put(this.rootUrl + `/clients/${client.clientId}/liability/term`,termId);
  }

  updateClientStatus(client:any, status: number){
    return this.http.put(this.rootUrl + `/clients/${client.clientId}/liability/status`,status);
  }

  delecteClientTerm(client:any){
    return this.http.delete(this.rootUrl + `/clients/${client.clientId}/liability`);
  }

}