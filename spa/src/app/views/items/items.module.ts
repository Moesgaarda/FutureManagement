import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewItemsComponent } from './view-items.component';
import { NewItemComponent } from './new-items.component';
import { DetailsItemComponent } from './details-item.component';
import { FormsModule } from '@angular/forms';
import { ItemsRoutingModule } from './items-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { Ng2TableModule } from 'ng2-table';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { EditItemComponent } from './edit-item.component';
import { TechTableModule } from '../../_modules/techtable/techtable.module';

@NgModule({
  imports: [
    ItemsRoutingModule,
    Ng2SmartTableModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule,
    PaginationModule.forRoot(),
    TechTableModule
  ],
  declarations: [
    ViewItemsComponent,
    NewItemComponent,
    DetailsItemComponent,
    EditItemComponent
   ]
})
export class ItemsModule { }
