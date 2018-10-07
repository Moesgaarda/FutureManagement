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

  constructor(private templateService: ItemTemplateService) {
    this.loadTemplates();
  }

  totalItems: number = 25;
  currentPage: number = 1;
  smallnumPages: number = 0;

  maxSize: number = 5;
  bigTotalItems: number = 675;
  bigCurrentPage: number = 1;
  numPages: number = 0;

  currentPager: number = 4;

  setPage(pageNo: number): void {
    this.currentPage = pageNo;
  }

  pageChanged(event: any): void {
    console.log('Page changed to: ' + event.page);
    console.log('Number items per page: ' + event.itemsPerPage);
  }

  async loadTemplates() {
    await this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
    });
  }

  editTemplate(templateToLoad) {
    location.href = this.baseUrl + '/pages/forms/item-template-detail/' + templateToLoad.data.id;
  }

  addNewTemplate() {
    location.href = this.baseUrl + '/pages/forms/item-template';
  }
}
