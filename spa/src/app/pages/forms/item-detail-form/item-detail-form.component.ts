import { Component, OnInit } from '@angular/core';
import { ItemService } from '../../../_services/item.service';
import { Item } from '../../../_models/Item';
import { Order } from '../../../_models/Order';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'ngx-item-detail-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-detail-form.component.html',
})
export class ItemDetailFormComponent implements OnInit {
  placementDisabled: boolean;
  nameDisabled: boolean;
  templateDisabled: boolean;
  amountDisabled: boolean;
  item: Item;

  constructor(private itemService: ItemService, private route: ActivatedRoute) {

  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.loadItem();
    this.templateDisabled = true;
    this.placementDisabled = true;
    this.amountDisabled = true;
  }

  async loadItem() {
    await this.itemService.getItem(+this.route.snapshot.params['id'])
    .subscribe((item: Item) => {
      this.item = item;
      console.log(this.item);
    })
  }

  enableTemplate() {
    if (this.templateDisabled) {
      this.templateDisabled = false;
    } else {
      // indsæt i db
      this.templateDisabled = true;
    }
  }

  enablePlacement() {
    if (this.placementDisabled) {
      this.placementDisabled = false;
    } else {
      // indsæt i db
      this.placementDisabled = true;
    }
  }

  enableAmount() {
    if (this.amountDisabled) {
      this.amountDisabled = false;
    } else {
      // indsæt i db
      this.amountDisabled = true;
    }
  }

  routeToOrderDetail() {
    location.href = 'http://localhost:4200/#/pages/forms/order-detail';
  }


}
