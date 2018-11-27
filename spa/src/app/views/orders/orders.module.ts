import { NgModule } from '@angular/core';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { OrdersRoutingModule } from './orders-routing.module';
import { Ng2TableModule } from 'ng2-table/ng2-table';

import { DetailsOrderComponent } from './details-order.component';
import { ViewOrdersComponent } from './view-orders.component';
import { NewOrderComponent } from './new-order.component';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { TechtableComponent } from '../../_components/techtable/techtable.component';

@NgModule({
  imports: [
    OrdersRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule,
  ],
  declarations: [
    ViewOrdersComponent,
    NewOrderComponent,
    DetailsOrderComponent,
    TechtableComponent
  ]
})
export class OrdersModule { }
