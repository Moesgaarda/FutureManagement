import { Component } from '@angular/core';
import { ItemService } from '../../_services/item.service';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';
import { Item } from '../../_models/Item';

@Component({
  templateUrl: './view-items.component.html',
  styles: [`
    nb-card {
      transform: translate3d(0, 0, 0);
    }
  `],
})
export class ViewItemsComponent {
    baseUrl = environment.spaUrl;
  items: Item[];

  constructor(private itemService: ItemService) {
    this.loadItems();
  }

  async loadItems() {
    await this.itemService.getAllItems().subscribe(items => {
      this.items = items;
    });
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Er du sikker på at du vil slette denne forekomst?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  editItem(itemToLoad): void {
    location.href = this.baseUrl + 'items/details/' + itemToLoad.data.id;
  }

  deleteItem(itemToDelete): void {
    if (window.confirm('Er du sikker på at du vil slette denne skabelon?')) {
      this.itemService.deleteItem(itemToDelete.data.id).subscribe(() => {
        this.items.splice(_.findIndex(this.items, {id: itemToDelete.data.id}), 1);
      });
    }
  }

  addNewItem() {
    location.href = this.baseUrl + 'items/new';
  }
}
