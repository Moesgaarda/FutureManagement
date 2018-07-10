import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { ItemTableService } from '../../../@core/data/item-table.service';

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

  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
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
      properties: {
        title: 'Egenskaber',
        type: 'string',
      },
      type: {
        title: 'Lavet af skabelon',
        type: 'string',
      },
      RouteToDetails:
      {
        title: 'Detaljer',
        type: 'html',
        filter: false,
        editable: false,
        valuePrepareFunction: (cell, row) => {
          // tslint:disable-next-line:max-line-length
          return `<a title="Se yderligere detaljer" width="10 px" href="/#/pages/forms/item-detail"> <i class="nb-edit"></i></a>`
        },

      },
      Id: { // this Id to use in ${row.Id}. Indættes efter item-detail.
        title: 'ID',
        type: 'number',
      },
    },
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(private service: ItemTableService) {
    const data = this.service.getData();
    this.source.load(data);
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Er du sikker på at du vil slette denne forekomst?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  route(event): void {
    location.href = 'http://localhost:4200/#/pages/forms/item-detail';
  }
}
