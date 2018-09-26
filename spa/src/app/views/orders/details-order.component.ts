import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  templateUrl: './details-order.component.html'
})

export class DetailsOrderComponent implements OnInit {
  orderIdDisabled: boolean;
  companyDisabled: boolean;
  orderDateDisabled: boolean;
  deliveryDateDisabled: boolean;
  purchaseNumberDisabled: boolean;
  lengthDisabled: boolean;
  widthDisabled: boolean;
  heightDisabled: boolean;
  unitTypeDisabled: boolean;

  ngOnInit() {
    this.orderIdDisabled = true;
    this.companyDisabled = true;
    this.orderDateDisabled = true;
    this.deliveryDateDisabled = true;
    this.purchaseNumberDisabled = true;
    this.lengthDisabled = true;
    this.widthDisabled = true;
    this.heightDisabled = true;
    this.unitTypeDisabled = true;
  }

  enableOrderId() {
    if (this.orderIdDisabled) {
      this.orderIdDisabled = false;
    } else {
      // indsæt i db
      this.orderIdDisabled = true;
    }
  }

  enableCompany() {
    if (this.companyDisabled) {
      this.companyDisabled = false;
    } else {
      // indsæt i db
      this.companyDisabled = true;
    }
  }

  enableOrderDate() {
    if (this.orderDateDisabled) {
      this.orderDateDisabled = false;
    } else {
      // indsæt i db
      this.orderDateDisabled = true;
    }
  }

  enableDeliveryDate() {
    if (this.deliveryDateDisabled) {
      this.deliveryDateDisabled = false;
    } else {
      // indsæt i db
      this.deliveryDateDisabled = true;
    }
  }

  enableLength() {
    if (this.lengthDisabled) {
      this.lengthDisabled = false;
    } else {
      // indsæt i db
      this.lengthDisabled = true;
    }
  }

  enableWidth() {
    if (this.widthDisabled) {
      this.purchaseNumberDisabled = false;
    } else {
      // indsæt i db
      this.widthDisabled = true;
    }
  }

  enableHeight() {
    if (this.heightDisabled) {
      this.heightDisabled = false;
    } else {
      // indsæt i db
      this.heightDisabled = true;
    }
  }

  enableUnitType() {
    if (this.unitTypeDisabled) {
      this.unitTypeDisabled = false;
    } else {
      // indsæt i db
      this.unitTypeDisabled = true;
    }
  }

  enablePurchaseNumber() {
    if (this.purchaseNumberDisabled) {
      this.purchaseNumberDisabled = false;
    } else {
      // indsæt i db
      this.purchaseNumberDisabled = true;
    }
  }
}
