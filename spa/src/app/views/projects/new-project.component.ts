import { Component, OnInit } from '@angular/core';
import { Order } from '../../_models/Order';
import { ItemTemplate } from '../../_models/ItemTemplate';
import { Item } from '../../_models/Item';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemPropertyDescription } from '../../_models/ItemPropertyDescription';
import { OrderService } from '../../_services/order.service';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { AlertifyService } from '../../_services/alertify.service';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { UnitType } from '../../_models/UnitType';


@Component({
  templateUrl: './new-project.component.html'
})

export class NewProjectComponent implements OnInit {
  orderToAdd: Order = {} as Order;
  unitTypeList: UnitType [] = [] as UnitType[];
  unitType: UnitType;
  currentItem: Item = {} as Item;
  templates: ItemTemplate[] = [];
  onOrderPage = true;
  templateToGet: ItemTemplate = {} as ItemTemplate;
  templateDetails: ItemTemplate = {} as ItemTemplate;
  detailsReady: boolean;
  propertyDescriptionsToAdd: ItemPropertyDescription[] = [] as ItemPropertyDescription[];
  descriptionTextsToAdd: string[] = [] as string[];

    constructor(private itemTemplateService: ItemTemplateService, private orderService: OrderService,
      private alertify: AlertifyService, private router: Router) {
      this.templateDetails.templateProperties = [] as ItemPropertyName[];
      this.orderToAdd.products = [] as Item[];
      this.currentItem.template = {} as ItemTemplate;
    }

    ngOnInit() {
      this.getTemplates();
      this.getUnitTypes();
    }

    changePage() {
      this.onOrderPage = !this.onOrderPage;
    }

    async getTemplates() {
      await this.itemTemplateService.getAll().subscribe(templates => {
        this.templates = templates;
      });
    }

    async getUnitTypes() {
      this.itemTemplateService.getUnitTypes().subscribe(unitTypes => {
        this.unitTypeList = unitTypes;
      });
    }

    async getTemplateDetails() {
      await this.itemTemplateService.getItemTemplate(this.templateToGet.id).subscribe(template => {
        this.templateDetails = template;
      }, error => {
        this.alertify.error('Kunne ikke hente skabelon');
      }, () => {
        this.detailsReady = true;
      });
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
      this.currentItem = {} as Item;
      this.propertyDescriptionsToAdd = [] as ItemPropertyDescription[];
      this.templateDetails = {} as ItemTemplate;
      this.templateToGet = {} as ItemTemplate;
    }

    addOrder() {
      this.orderService.addOrder(this.orderToAdd).subscribe(data => {
        this.alertify.success('Tilføjede bestilling');
        console.log(this.orderToAdd);
      }, error => {
        this.alertify.error('Kunne ikke tilføje bestillingen');
      }, () => {
        this.router.navigate(['projects/view']);
      });
    }
}
