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
  templateUrl: './new-project.component.html'
})

export class NewProjectComponent implements OnInit {
  orderToAdd: Order = {} as Order;
    unitTypes = Object.keys(UnitType);
    currentItem: Item = {} as Item;
    templates: ItemTemplate[] = [];
    onOrderPage: boolean = true;
    templateToGet: ItemTemplate = {} as ItemTemplate;
    templateDetails: ItemTemplate = {} as ItemTemplate;
    detailsReady: boolean;
    unitTypeForAmount: string;
    propertyDescriptionsToAdd: ItemPropertyDescription[] = [] as ItemPropertyDescription[];
    descriptionTextsToAdd: string[] = [] as string[];

    constructor(private itemTemplateService: ItemTemplateService, private orderService: OrderService,
      private alertify: AlertifyService, private router: Router) {
      this.getTemplates();
      this.templateDetails.templateProperties = [] as ItemPropertyName[];
      this.orderToAdd.products = [] as Item[];
      this.currentItem.template = {} as ItemTemplate;
    }

    ngOnInit() {
      this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
    }

    changePage() {
      this.onOrderPage = !this.onOrderPage;
    }

    async getTemplates() {
      await this.itemTemplateService.getAll().subscribe(templates => {
        this.templates = templates;
      })

    }

    async getTemplateDetails() {
      await this.itemTemplateService.getItemTemplate(this.templateToGet.id).subscribe(template => {
        this.templateDetails = template;
      }, error => {
        this.alertify.error('kunne ikke hente skabelon');
      }, () => {
        this.detailsReady = true;
        this.getUnitTypeForTemplate();
      });
    }


    getUnitTypeForTemplate() {
      this.unitTypeForAmount = UnitType[this.templateDetails.unitType];
    }

    removeItemFromOrder(i: number) {
      this.orderToAdd.products.splice(i, 1);
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
      this.orderToAdd.products.push(this.currentItem);
      this.changePage();
      console.log(this.orderToAdd);
      this.currentItem = {} as Item;
      this.propertyDescriptionsToAdd = [] as ItemPropertyDescription[];
      this.templateDetails = {} as ItemTemplate;
      this.templateToGet = {} as ItemTemplate;
    }

    addOrder() {
      this.orderService.addOrder(this.orderToAdd).subscribe(data => {
        console.log('added order');
        this.alertify.success('Tilføjede bestilling');
        console.log(this.orderToAdd);
      }, error => {
        console.log('failed to add order');
        this.alertify.error('kunne ikke tilføje bestillingen');
      }, () => {
        this.router.navigate(['projects/view']);
      });
    }
}
