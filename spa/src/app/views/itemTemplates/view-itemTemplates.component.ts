import { Component, OnInit, ViewEncapsulation  } from '@angular/core';

import { ItemTemplate, UnitType } from '../../_models/ItemTemplate';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';

@Component({
  templateUrl: './view-itemTemplates.component.html',
  encapsulation: ViewEncapsulation.None
})

export class ViewItemTemplatesComponent {
  templates: ItemTemplate[];
  templatesToShow: ItemTemplate[];
  baseUrl = environment.spaUrl;

  totalItems: number;
  currentPage: number;
  lower: number;
  upper: number;

  constructor(private templateService: ItemTemplateService) {
    this.loadTemplates();
  }

  pageChanged(event: any): void {
    this.lower = event.itemsPerPage * (event.page - 1);
    this.upper = (event.itemsPerPage * event.page) - 1;
    console.log('Lower: ' + this.lower);
    console.log('Upper: ' + this.upper);
    this.templatesToShow = this.templates.slice(this.lower, this.upper);
  }

  loadTemplates() {
    this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
      this.totalItems = this.templates.length;
      this.templatesToShow = this.templates.slice(0, 15);
    });
  }

  editTemplate(templateToLoad) {
    location.href = this.baseUrl + '/pages/forms/item-template-detail/' + templateToLoad.data.id;
  }

  addNewTemplate() {
    location.href = this.baseUrl + '/pages/forms/item-template';
  }
}
