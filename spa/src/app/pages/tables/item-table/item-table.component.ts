import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { ItemService } from '../../../_services/item.service';
import { environment } from '../../../../environments/environment';
import * as _ from 'underscore';
import { Item } from '../../../_models/Item';


@Component({
  selector: 'ngx-item-table',
  templateUrl: './item-table.component.html',
  styles: [`
    nb-card {
      transform: translate3d(0, 0, 0);
    }
  `],
})
export class ItemTableComponent {
  baseUrl = environment.spaUrl;
  source: LocalDataSource;
  items: Item[];


  settings = {
    pager: {
      perPage: 15,
    },
    mode: 'external',
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    add: {
      addButtonContent: 'Tilføj ny',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    columns: {
      name: {
        title: 'Navn',
        type: 'string',
      },
      placement: {
        title: 'Placering',
        type: 'string',
      },
      amount: {
        title: 'Mængde',
        type: 'string',
      },
      order: {
        title: 'Ordre',
        type: 'string',
      },
      type: {
        title: 'Lavet af skabelon',
        type: 'string',
      },
    },
  };

  constructor(private itemService: ItemService) {
    this.source = new LocalDataSource();
    this.loadItems();
  }

  async loadItems() {
    await this.itemService.getItems().subscribe(items => {
      this.items = items;
      this.source.load(items);
      this.source.refresh();
    })
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Er du sikker på at du vil slette denne forekomst?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  editItem(event): void {
    location.href = this.baseUrl + '/pages/forms/item-detail';
  }

  deleteItem(event): void {
    if (window.confirm('Er du sikker på at du vil slette denne forekomst?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  addNewItem() {
    location.href = this.baseUrl + '/pages/forms/item';
  }
}
