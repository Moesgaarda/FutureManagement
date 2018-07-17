import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { ItemTemplateTableService } from '../../../@core/data/item-template-table.service';
import { ItemTemplate } from '../../../_models/ItemTemplate';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';

@Component({
  selector: 'ngx-item-template-table',
  templateUrl: './item-template-table.component.html',
  styles: [`
    nb-card {
      transform: translate3d(0, 0, 0);
    }
  `],
})
export class ItemTemplateTableComponent  {
  source: LocalDataSource;
  templates: ItemTemplate[];
  template: ItemTemplate;

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
      unitType: {
        title: 'Mængdeenhed',
        type: 'number',
      },
      description: {
        title: 'Beskrivelse',
        type: 'string',
      },
      files: {
        title: 'Fil',
        type: 'string',
      },
    },
  };

  constructor(private templateService: ItemTemplateService) {
    this.source = new LocalDataSource();
    this.loadTemplates();
  }



  onDeleteConfirm(event): void {
    if (window.confirm('Er du sikker på at du vil slette denne skabelon?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }


  loadTemplates() {
    this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
      this.source.load(templates);
      this.source.refresh();
    })
  }

  editTemplate(event): void {
    
  }

  deleteTemplate(event): void {

  }

  addNewTemplate() {
    location.href = 'http://localhost:4200/#/pages/forms/item-template';
  }
}
