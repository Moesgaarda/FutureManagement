import { NgModule } from '@angular/core';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ItemTemplatesRoutingModule } from './itemTemplates-routing.module';
import { Ng2TableModule } from 'ng2-table/ng2-table';

import { DetailsItemTemplateComponent } from './details-itemTemplate.component';
import { ViewItemTemplatesComponent } from './view-itemTemplates.component';
import { NewItemTemplateComponent } from './new-itemTemplate.component';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { ReviseItemTemplateComponent } from './revise-itemTemplate.component';


@NgModule({
  imports: [
    ItemTemplatesRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule
  ],
  declarations: [
    ViewItemTemplatesComponent,
    NewItemTemplateComponent,
    DetailsItemTemplateComponent,
    ReviseItemTemplateComponent ]
})
export class ItemTemplatesModule { }
