import { Component, OnInit, ViewChild } from '@angular/core';
import { GeneralService } from '../shared/services/general.service';
import { MatTable, MatDialog } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientDetailsDialogComponent } from '../client-details-dialog/client-details-dialog.component';
import { ClientService } from '../shared/services/client.service';
import { ClientAddDialogComponent } from '../client-add-dialog/client-add-dialog.component';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.css']
})
export class ClientsComponent implements OnInit {

  columnsToDisplay = ['firstName', 'lastName', 'personalId'];
  clients: any;
  @ViewChild("table")
  table: MatTable<any>;

  constructor(
    private clientService: ClientService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private dialog: MatDialog) { }

  ngOnInit() {
    this.getClients();

  }

  getClients() {
    return this.clientService.getClients().subscribe(resp => {
      this.clients = resp;
      if (this.table)
        this.table.renderRows();
    });
  }

  selectRow(client: any) {
    this.clientService.getClientDetails(client).subscribe(resp => {
      let dialogRef = this.dialog.open(ClientDetailsDialogComponent, {
        height: '580px',
        width: '350px',
        data: { userDetails: resp, clientId: client.clientId }
      });
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          if (result !== "delete") {
            this.clientService.updateClientTerm(client, result.liabilityTermId).subscribe(response => {

            });
            this.clientService.updateClientStatus(client, result.status).subscribe(response => {

            })
          }
          else{
            this.clientService.delecteClientTerm(client).subscribe(resp=>{

            })
          }
        }

      });
    });
  }

  addClick() {
    let dialogRef = this.dialog.open(ClientAddDialogComponent, {
      height: '880px',
      width: '400px',
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.clientService.registerClient(result).subscribe(response => {
          this.getClients();
        });
      }
    })
  }

}
