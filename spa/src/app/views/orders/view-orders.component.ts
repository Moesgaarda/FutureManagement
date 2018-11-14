import { Component, OnInit } from '@angular/core';
import { Order } from '../../_models/Order';
import { UnitType, ItemTemplate } from '../../_models/ItemTemplate';
import { Item } from '../../_models/Item';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemPropertyDescription } from '../../_models/ItemPropertyDescription';
import { OrderService } from '../../_services/order.service';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { AlertifyService } from '../../_services/alertify.service';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  templateUrl: './view-orders.component.html'
})
export class ViewOrdersComponent {

}
