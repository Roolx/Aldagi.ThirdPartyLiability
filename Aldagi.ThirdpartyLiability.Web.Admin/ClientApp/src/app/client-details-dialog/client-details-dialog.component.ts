import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Component, Input, Inject } from "@angular/core";
import { TermService } from "../shared/services/term.service";
import { ClientService } from "../shared/services/client.service";

@Component({
  selector: 'client-details-dialog',
  templateUrl: './client-details-dialog.component.html'
})
export class ClientDetailsDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, @Inject(MAT_DIALOG_DATA) public clientId: any, public dialogRef: MatDialogRef<ClientDetailsDialogComponent>, private termService: TermService, private clientService: ClientService) { }

  private terms: any;
  private clientTermDetails;
  private statuses: any;

  ngOnInit() {
    this.clientTermDetails = [];
    this.terms = [];
    this.statuses = [];

    this.termService.getStatuses().subscribe(response => {
      this.statuses = response;
    })

    this.clientService.getTermDetails(this.clientId).subscribe(response => {
      this.clientTermDetails = response;
    });

    this.termService.getTerms().subscribe(response => {
      this.terms = response;

    })
  }

  closeDialog(action: any) {
    if (action == "update")
      this.dialogRef.close(this.clientTermDetails);
    else if (action == "delete")
      this.dialogRef.close("delete");
  }
}