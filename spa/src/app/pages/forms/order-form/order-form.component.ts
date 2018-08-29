import { Component, OnInit } from '@angular/core';
import { Order } from '../../../_models/Order';
import { UnitType, ItemTemplate } from '../../../_models/ItemTemplate';
import { Item } from '../../../_models/Item';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemPropertyDescription } from '../../../_models/ItemPropertyDescription';
import { OrderService } from '../../../_services/order.service';
import { ItemPropertyName } from '../../../_models/ItemPropertyName';

@Component({
  selector: 'ngx-order-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './order-form.component.html',
})

export class OrderFormComponent implements OnInit {
    orderToAdd: Order = {} as Order;
    unitTypes = Object.keys(UnitType);
    currentItem: Item = {} as Item;
    templates: ItemTemplate[] = [];
    onOrderPage: boolean = true;
    templateToGet: ItemTemplate = {} as ItemTemplate;
    templateDetails: ItemTemplate = {} as ItemTemplate;
    detailsReady: boolean;
    propertyDescriptionsToAdd: ItemPropertyDescription[] = [] as ItemPropertyDescription[];
    descriptionTextsToAdd: string[] = [] as string[];

    constructor(private itemTemplateService: ItemTemplateService, private orderService: OrderService) {
      this.getTemplates();
      this.templateDetails.templateProperties = [] as ItemPropertyName[];
      this.orderToAdd.items = [] as Item[];
      this.currentItem.template = {} as ItemTemplate;
    }

    ngOnInit() {
      this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
    }

    changePage() {
      this.onOrderPage = !this.onOrderPage;
    }

    async getTemplates() {
      await this.itemTemplateService.getItemTemplates().subscribe(templates => {
        this.templates = templates;
      })

    }

    async getTemplateDetails() {
      await this.itemTemplateService.getItemTemplate(this.templateToGet.id).subscribe(template => {
        this.templateDetails = template;
      })
      this.detailsReady = true;
    }

    removeItemFromOrder(i: number) {
      this.orderToAdd.items.splice(i, 1);
    }

    addItemToOrder() {
      for (let i = 0; i < this.templateDetails.templateProperties.length; i++) {
        this.propertyDescriptionsToAdd.push({
          description: this.descriptionTextsToAdd[i],
          propertyName: this.templateDetails.templateProperties[i],
        });
      }

      this.currentItem.properties = this.propertyDescriptionsToAdd;
      this.currentItem.template = this.templateDetails;
      this.currentItem.isActive = true;
      this.orderToAdd.items.push(this.currentItem);
      this.changePage();
      console.log(this.orderToAdd);
      this.currentItem = {} as Item;
      this.propertyDescriptionsToAdd = [] as ItemPropertyDescription[];
      this.templateDetails = {} as ItemTemplate;
    }

}

