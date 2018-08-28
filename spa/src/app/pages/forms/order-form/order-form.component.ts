import { Component, OnInit } from '@angular/core';
import { Order } from '../../../_models/Order';
import { UnitType } from '../../../_models/ItemTemplate';

@Component({
  selector: 'ngx-order-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './order-form.component.html',
})

export class OrderFormComponent implements OnInit {
    orderToAdd: Order;
    unitTypes = Object.keys(UnitType);

    ngOnInit() {
      this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
    }
}

