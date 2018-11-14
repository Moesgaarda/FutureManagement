import { NgModule } from '@angular/core';

import { DetailsOrderComponent } from './details-order.component';
import { ViewOrdersComponent } from './view-orders.component';
import { NewOrderComponent } from './new-order.component';
import { FormsModule } from '@angular/forms';
import { OrdersRoutingModule } from './orders-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { Ng2TableModule } from 'ng2-table/ng2-table';

@NgModule({
  imports: [
    OrdersRoutingModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
    PaginationModule.forRoot(),
    NgSelectModule,
    Ng2TableModule
  ],
  declarations: [
    ViewOrdersComponent,
    NewOrderComponent,
    DetailsOrderComponent
  ]
})
export class OrdersModule { }
