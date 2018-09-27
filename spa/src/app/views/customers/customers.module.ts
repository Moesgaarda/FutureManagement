import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewCustomersComponent } from './view-customers.component';

import { CustomersRoutingModule } from './customers-routing.module';
import { NewCustomerComponent } from './new-customer.component';
import { DetailsCustomerComponent } from './details-customer.component';

@NgModule({
  imports: [
    CustomersRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [
    ViewCustomersComponent,
    NewCustomerComponent,
    DetailsCustomerComponent ]
})
export class CustomersModule { }
