import { Component } from '@angular/core';

@Component({
  selector: 'ngx-item-detail-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-detail-form.component.html',
})
export class ItemDetailFormComponent {
  placementDisabled: boolean;
  nameDisabled: boolean;
  templateDisabled: boolean;
  amountDisabled: boolean;

  ngOnInit() {
    this.nameDisabled = true;
    this.templateDisabled = true;
    this.placementDisabled = true;
    this.amountDisabled = true;
  }

  enableName() {
    if (this.nameDisabled) {
      this.nameDisabled = false;
    }
    else {
      // indsæt i db
      this.nameDisabled = true;
    }   
  }

  enableTemplate() {
    if (this.templateDisabled) {
      this.templateDisabled = false;
    }
    else {
      // indsæt i db
      this.templateDisabled = true;
    }
  }

  enablePlacement() {
    if (this.placementDisabled) {
      this.placementDisabled = false;
    }
    else {
      // indsæt i db
      this.placementDisabled = true;
    }
  }

  enableAmount() {
    if (this.amountDisabled) {
      this.amountDisabled = false;
    }
    else {
      // indsæt i db
      this.amountDisabled = true;
    }
  }

  routeToOrderDetail() {
    location.href = 'http://localhost:4200/#/pages/forms/order-detail';
  }


}
