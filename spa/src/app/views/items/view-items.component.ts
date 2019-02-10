import { Component, OnInit } from '@angular/core';
import { ItemService } from '../../_services/item.service';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';
import { Item } from '../../_models/Item';

import { AlertifyService } from '../../_services/alertify.service';

@Component({
  templateUrl: './view-items.component.html'
})
export class ViewItemsComponent {}
