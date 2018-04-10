import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Component, Input, Inject } from "@angular/core";
import { CarService } from "../shared/services/car.service";
import { TermService } from "../shared/services/term.service";

@Component({
  selector: 'client-add-dialog',
  templateUrl: './client-add-dialog.component.html'
})
export class ClientAddDialogComponent {
  constructor(private dialogRef: MatDialogRef<ClientAddDialogComponent>, private carService: CarService, private termService: TermService) { }
  private userData: any;
  private cars: any;
  private manufacturers: any;
  private terms: any;
  private selectedManufacturer: any;

  ngOnInit() {
    this.userData = {};
    this.carService.getManufacturers().subscribe(response => {
      this.manufacturers = response;
    });
    this.termService.getTerms().subscribe(response => {
      this.terms = response;
    })
  }

  getCars() {
    this.carService.getCars(this.selectedManufacturer).subscribe(response => {
      this.cars = response;
    })
  }

  closeDialog() {
    this.dialogRef.close(this.userData);
  }
}