import {Component, OnInit} from '@angular/core';
import {ItemService} from '../../_services/item.service';
import {Item} from '../../_models/Item';
import {ActivatedRoute, Router} from '@angular/router';
import {environment} from '../../../environments/environment';
import {AlertifyService} from '../../_services/alertify.service';


@Component({
  templateUrl: './details-item.component.html'
})
export class DetailsItemComponent implements OnInit {
  item: Item;
  idForOrderDetail: number;
  baseUrl = environment.spaUrl;
  itemLoaded: boolean;
  partsLoaded: boolean;
  parts: Item[] = [] as Item[];


  constructor(private itemService: ItemService, private route: ActivatedRoute, private router: Router,
              private alertify: AlertifyService
  ) {
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.loadItem();
  }

  async loadItem() {
    await this.itemService
      .getItem(+this.route.snapshot.params['id'])
      .subscribe((itemToLoad: Item) => {
        this.item = itemToLoad;
        this.loadParts();
      }, error => {
        this.alertify.error('Kunne ikke hente info om genstanden');
      }, () => {
        this.itemLoaded = true;
      });
  }

  async loadParts() {
    this.item.parts.forEach(part => {
      this.itemService.getItem(part.part.id).subscribe(item => {
        this.parts.push(item);
      }, error => {
        this.alertify.error('Kunne ikke hente info om genstanden');
      }, () => {
        if (this.parts.length === this.item.parts.length) {
          this.partsLoaded = true;
        }
      });
    });
  }

  goToOrder() {
    this.router.navigate(['orders/details/' + this.idForOrderDetail]);
  }


  goToEditPage() {
    this.router.navigate(['items/edit/' + this.item.id]);
  }

  goToTemplate() {
    this.router.navigate(['itemTemplates/details/' + this.item.template.id]);
  }
}
