import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewItemsComponent } from './view-items.component';

import { ItemsRoutingModule } from './items-routing.module';

@NgModule({
  imports: [
    ItemsRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [ ViewItemsComponent ]
})
export class ItemsModule { }
