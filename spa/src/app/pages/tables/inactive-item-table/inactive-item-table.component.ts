import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { ItemService } from '../../../_services/item.service';
import { environment } from '../../../../environments/environment';
import * as _ from 'underscore';
import { Item } from '../../../_models/Item';


@Component({
  selector: 'ngx-inactive-item-table',
  templateUrl: './inactive-item-table.component.html',
  styles: [`
    nb-card {
      transform: translate3d(0, 0, 0);
    }
  `],
})
export class InactiveItemTableComponent {
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
      template: {
        title: 'Lavet af skabelon',
        valuePrepareFunction: (temp) => {
          return temp.name.toString();
        },
        filterFunction(temp?: any, search?: string): boolean {
          const match = temp.name.toLowerCase().indexOf(search.toLowerCase()) > -1
          if (match || search === '') {
            return true;
          } else {
            return false;
          }
        },
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
        title: 'Købt fra eller lavet af',
        valuePrepareFunction: (order) => {
          return order.company.toString()
        },
        filterFunction(order?: any, search?: string): boolean {
          const match = order.company.indexOf(search) > -1
          if (match || search === '') {
            return true;
          } else {
            return false;
          }
        },
      },
    },
  };

  constructor(private itemService: ItemService) {
    this.source = new LocalDataSource();
    this.loadItems();
  }

  async loadItems() {
    await this.itemService.getInactiveItems().subscribe(items => {
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

  editItem(itemToLoad): void {
    location.href = this.baseUrl + '/pages/forms/item-detail/' + itemToLoad.data.id;
  }

  deleteItem(itemToDelete): void {
    if (window.confirm('Er du sikker på at du vil slette denne skabelon?')) {
      this.itemService.deleteItem(itemToDelete.data.id).subscribe(() => {
        this.items.splice(_.findIndex(this.items, {id: itemToDelete.data.id}), 1);
        this.source.refresh();
      });
    }
  }

  addNewItem() {
    location.href = this.baseUrl + '/pages/forms/item';
  }

  redirectToActive() {
    location.href = this.baseUrl + 'pages/tables/active-item-table';
  }
}
