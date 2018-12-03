import { NgModule } from '@angular/core';

import { DetailsOrderComponent } from './details-order.component';
import { ViewOrdersComponent } from './view-orders.component';
import { NewOrderComponent } from './new-order.component';
import { FormsModule } from '@angular/forms';
import { OrdersRoutingModule } from './orders-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TechtableComponent } from '../../_components/techtable/techtable.component';

@NgModule({
  imports: [
    OrdersRoutingModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
    PaginationModule.forRoot(),
  ],
  declarations: [
    ViewOrdersComponent,
    NewOrderComponent,
    DetailsOrderComponent,
    TechtableComponent
  ]
})
export class OrdersModule { }
