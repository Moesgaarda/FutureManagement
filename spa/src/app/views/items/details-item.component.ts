import { Component, OnInit } from '@angular/core';
import { ItemService } from '../../_services/item.service';
import { Item } from '../../_models/Item';
import { Order } from '../../_models/Order';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  templateUrl: './details-item.component.html'
})
export class DetailsItemComponent implements OnInit {
  item: Item;
  idForOrderDetail: number;
  baseUrl = environment.spaUrl;
  parts: Item [];

  constructor(private itemService: ItemService, private route: ActivatedRoute, private router: Router
  ) {}

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.loadItem();
  }

  async loadItem() {
    await this.itemService
      .getItem(+this.route.snapshot.params['id'])
      .subscribe((item: Item) => {
        this.item = item;
        this.idForOrderDetail = item.order.id;
        console.log(this.item);
      });
  }

  goToOrder() {
    this.router.navigate(['orders/details/:idForOrderDetail']);
  }

  getPart(id: number) {
    return this.itemService.getItem(id);
  }

}
