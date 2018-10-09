import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
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
  source: LocalDataSource;
  items: Item[];


  settings = {
    attr: {
        class: 'table table-striped pagination'
      },
    pager: {
      perPage: 15,
    },
    mode: 'external',
    delete: {
      deleteButtonContent: '<i class="btn btn-sm btn-danger fa fa-trash"> Slet </i>',
      confirmDelete: true,
    },
    add: {
      addButtonContent: 'Tilføj ny genstand'
    },
    edit: {
      editButtonContent: '<i class="btn btn-sm btn-primary fa fa-edit"> Rediger </i>',
      saveButtonContent: '<i class="btn btn-sm btn-info fa fa-save"> Gem </i>',
      cancelButtonContent: '<i class="btn btn-sm btn-warning fa fa-trash"> Fortryd </i>',
    },
    columns: {
      template: {
        title: 'Lavet af skabelon',
        valuePrepareFunction: (temp) => {
          return temp.name.toString();
        },
        filterFunction(temp?: any, search?: string): boolean {
          const match = temp.name.toLowerCase().indexOf(search.toLowerCase()) > -1;
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
        title: 'Ordre',
        type: 'html',
        valuePrepareFunction: (order) => {
          if (order == null) {
            return 'Ikke indkøbt';
          }
          return `<a href="/#/orders/details/${order.id}">${order.company}</a>`;
        },
        filterFunction(order?: any, search?: string): boolean {
          const match = order.company.indexOf(search) > -1;
          if (match || search === '') {
            return true;
          } else {
            return false;
          }
        },
      },
      createdBy: {
        title: 'Lavet af',
        type: 'string',
        valuePrepareFunction: (createdBy) => {
          if (createdBy == null) {
            return 'Denne genstand er indkøbt';
          }
          return createdBy.username;
        },
      }
    },
  };

  constructor(private itemService: ItemService) {
    this.source = new LocalDataSource();
    this.loadItems();
  }

  async loadItems() {
    await this.itemService.getAllItems().subscribe(items => {
      this.items = items;
      this.source.load(items);
      this.source.refresh();
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
}
