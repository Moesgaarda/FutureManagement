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
import { TechtableComponent } from '../../_components/techtable/techtable.component';
import { PropertyFilterPipe } from './property-filter.pipe';


@NgModule({
  imports: [
    ItemTemplatesRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule,
  ],
  declarations: [
    ViewItemTemplatesComponent,
    NewItemTemplateComponent,
    DetailsItemTemplateComponent,
    ReviseItemTemplateComponent,
    TechtableComponent,
    PropertyFilterPipe
   ]
})
export class ItemTemplatesModule { }
