import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { ItemTemplate, UnitType } from '../../../_models/ItemTemplate';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { environment } from '../../../../environments/environment';
import * as _ from 'underscore';

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
  baseUrl = environment.spaUrl;

  settings = {
    pager: {
      perPage: 10,
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
        valuePrepareFunction: (value) => UnitType[value],
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

  async loadTemplates() {
    await this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
      this.source.load(templates);
      this.source.refresh();
    })
  }

  editTemplate(templateToLoad) {
    location.href = this.baseUrl + '/pages/forms/item-template-detail/' + templateToLoad.data.id;
  }

  deleteTemplate(templateToDelete) {
    if (window.confirm('Er du sikker på at du vil slette denne skabelon?')) {
      this.templateService.deleteItemTemplate(templateToDelete.data.id).subscribe(() => {
        this.templates.splice(_.findIndex(this.templates, {id: templateToDelete.data.id}), 1);
        this.source.refresh();
      });
    }
  }

  addNewTemplate() {
    location.href = this.baseUrl + '/pages/forms/item-template';
  }
}
