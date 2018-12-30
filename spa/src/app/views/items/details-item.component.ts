import { Component, OnInit } from '@angular/core';
import { ItemService } from '../../_services/item.service';
import { Item } from '../../_models/Item';
import { Order } from '../../_models/Order';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  templateUrl: './details-item.component.html'
})
export class DetailsItemComponent implements OnInit {
  item: Item;
  idForOrderDetail: number;
  baseUrl = environment.spaUrl;
  parts: Item [];
  itemLoaded: boolean;

  constructor(private itemService: ItemService, private route: ActivatedRoute, private router: Router,
    private alertify: AlertifyService
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
      }, error => {
        this.alertify.error('Kunne ikke hente info om genstanden');
      }, () => {
        this.itemLoaded = true;
      });
  }

  goToOrder() {
    this.router.navigate(['orders/details/:idForOrderDetail']);
  }

  getPart(id: number) {
    return this.itemService.getItem(id);
  }

  goToEditPage() {
    this.router.navigate(['items/edit/' + this.item.id]);
  }
}
