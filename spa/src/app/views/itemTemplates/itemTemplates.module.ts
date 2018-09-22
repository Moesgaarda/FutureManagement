import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewItemTemplatesComponent } from './view-itemTemplates.component';

import { ItemTemplatesRoutingModule } from './itemTemplates-routing.module';

@NgModule({
  imports: [
    ItemTemplatesRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [ ViewItemTemplatesComponent ]
})
export class ItemTemplatesModule { }
