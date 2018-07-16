import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { ItemTemplateTableService } from '../../../@core/data/item-template-table.service';

@Component({
  selector: 'ngx-item-template-table',
  templateUrl: './item-template-table.component.html',
  styles: [`
    nb-card {
      transform: translate3d(0, 0, 0);
    }
  `],
})
export class ItemTemplateTableComponent {

  settings = {
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
      templateName: {
        title: 'Navn',
        type: 'string',
      },
      amountUnit: {
        title: 'Mængdeenhed',
        type: 'number',
      },
      description: {
        title: 'Beskrivelse',
        type: 'string',
      },
      file: {
        title: 'Fil',
        type: 'string',
      },
    },
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(private service: ItemTemplateTableService) {
    const data = this.service.getData();
    this.source.load(data);
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Er du sikker på at du vil slette denne skabelon?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  editTemplate(event): void {
    location.href = 'http://localhost:4200/#/pages/forms/item-template-detail';
  }

  deleteTemplate(event): void {

  }

  addNewTemplate() {
    location.href = 'http://localhost:4200/#/pages/forms/item-template';
  }
}
