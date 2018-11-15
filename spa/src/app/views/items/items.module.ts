import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewItemsComponent } from './view-items.component';
import { AddItemsComponent } from './new-items.component';
import { DetailsItemComponent } from './details-item.component';
import { FormsModule } from '@angular/forms';
import { ItemsRoutingModule } from './items-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { Ng2TableModule } from 'ng2-table';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  imports: [
    ItemsRoutingModule,
    Ng2SmartTableModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule,
    PaginationModule.forRoot(),
  ],
  declarations: [
    ViewItemsComponent,
    AddItemsComponent,
    DetailsItemComponent,
   ]
})
export class ItemsModule { }
