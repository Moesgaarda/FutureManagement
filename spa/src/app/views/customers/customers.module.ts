import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewCustomersComponent } from './view-customers.component';

import { CustomersRoutingModule } from './customers-routing.module';

@NgModule({
  imports: [
    CustomersRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [ ViewCustomersComponent ]
})
export class CustomersModule { }
