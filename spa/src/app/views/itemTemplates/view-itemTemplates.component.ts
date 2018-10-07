import { Component, OnInit, ViewEncapsulation, Input } from '@angular/core';

import { ItemTemplate, UnitType } from '../../_models/ItemTemplate';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';

@Component({
  templateUrl: './view-itemTemplates.component.html',
  styles: ['.pager li.btn:active { box-shadow: none; }'],
  encapsulation: ViewEncapsulation.None
})

export class ViewItemTemplatesComponent {
  templates: ItemTemplate[];
  baseUrl = environment.spaUrl;

  totalItems: number;
  currentPage: number;

  constructor(private templateService: ItemTemplateService) {
    this.loadTemplates();
  }

  setPage(pageNo: number): void {
    this.currentPage = pageNo;
  }

  pageChanged(event: any): void {
    console.log('Page changed to: ' + event.page);
    console.log('Number items per page: ' + event.itemsPerPage);
  }

  loadTemplates() {
    this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
      this.totalItems = this.templates.length;
    });
  }

  editTemplate(templateToLoad) {
    location.href = this.baseUrl + '/pages/forms/item-template-detail/' + templateToLoad.data.id;
  }

  addNewTemplate() {
    location.href = this.baseUrl + '/pages/forms/item-template';
  }
}
