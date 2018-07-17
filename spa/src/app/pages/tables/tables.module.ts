import { NgModule } from '@angular/core';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';
import { TablesRoutingModule, routedComponents } from './tables-routing.module';
import { SmartTableService } from '../../@core/data/smart-table.service';
import { ItemTableService } from '../../@core/data/item-table.service';
import { ItemTemplateTableService } from '../../@core/data/item-template-table.service';
import { ItemTemplateService } from '../../_services/itemTemplate.service';

@NgModule({
  imports: [
    ThemeModule,
    TablesRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ...routedComponents,
  ],
  providers: [
    SmartTableService,
    ItemTableService,
    ItemTemplateTableService,
    ItemTemplateService,
  ],
})
export class TablesModule { }
