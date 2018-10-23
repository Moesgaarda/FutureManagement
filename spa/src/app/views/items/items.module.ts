import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewItemsComponent } from './view-items.component';
import { AddItemsComponent } from './new-items.component';
import { DetailsItemComponent } from './details-item.component';
import { FormsModule } from '@angular/forms';
import { ItemsRoutingModule } from './items-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { FutmanTableComponent } from '../../_components/futman-table/futman-table.component';

@NgModule({
  imports: [
    ItemsRoutingModule,
    Ng2SmartTableModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
  ],
  declarations: [
    ViewItemsComponent,
    AddItemsComponent,
    DetailsItemComponent,
    FutmanTableComponent
   ]
})
export class ItemsModule { }
