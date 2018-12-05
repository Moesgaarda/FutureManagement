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
  templateUrl: './new-order.component.html'
})
export class NewOrderComponent implements OnInit {
  orderToAdd: Order = {} as Order;
  unitTypes = Object.keys(UnitType);
  currentItem: Item = {} as Item;
  templates: ItemTemplate[] = [];
  onOrderPage = true;
  templateToGet: ItemTemplate = {} as ItemTemplate;
  templateDetails: ItemTemplate = {} as ItemTemplate;
  detailsReady: boolean;
  unitTypeForAmount: string;
  propertyDescriptionsToAdd: ItemPropertyDescription[] = [] as ItemPropertyDescription[];
  descriptionTextsToAdd: string[] = [] as string[];

  constructor(
    private itemTemplateService: ItemTemplateService,
    private orderService: OrderService,
    private alertify: AlertifyService,
    private router: Router
  ) {
    this.templateDetails.templateProperties = [] as ItemPropertyName[];
    this.orderToAdd.products = [] as Item[];
    this.currentItem.template = {} as ItemTemplate;
  }

  async ngOnInit() {
    await this.getTemplates();
    // we only need the lenght measurements
    this.unitTypes = this.unitTypes.slice(6, 9);
  }

  /**
   * This method is used to switch between page for adding details to order and adding items to order
   *
   * @memberof NewOrderComponent
   */
  changePage() {
    this.onOrderPage = !this.onOrderPage;
  }

  
  /**
   * Gets all the ItemTemplates from the api
   *
   * @memberof NewOrderComponent
   */
  async getTemplates() {
    await this.itemTemplateService.getAll().subscribe(templates => {
      this.templates = templates;
    });
  }


  /**
   * Gets details for a specific ItemTemplate
   * Is used when the user chooses one ItemTemplate to add to the order
   * Because the templates that are retrieved when getting all templates at once don't have all the details of the ItemTemplate
   * 
   * @memberof NewOrderComponent
   */
  async getTemplateDetails() {
    await this.itemTemplateService
      .getItemTemplate(this.templateToGet.id)
      .subscribe(
        template => {
          this.templateDetails = template;
          console.log(template);
        },
        error => {
          this.alertify.error('kunne ikke hente skabelon');
        },
        () => {
          this.detailsReady = true;
          this.getUnitTypeForTemplate();
        }
      );
  }


  /**
   * Extracts the unitType from the ItemTemplate that is being added to the Order
   *
   * @memberof NewOrderComponent
   */
  getUnitTypeForTemplate() {
    this.unitTypeForAmount = UnitType[this.templateDetails.unitType];
  }

  /**
   *
   * Removes a Item i from the Order
   *
   * @param {number} i
   * @memberof NewOrderComponent
   */
  removeItemFromOrder(i: number) {
    this.orderToAdd.products.splice(i, 1);
  }

  /**
   * Adds an item to the order with all it's details
   *
   * @memberof NewOrderComponent
   */
  addItemToOrder() {
    for (let i = 0; i < this.templateDetails.templateProperties.length; i++) {
      this.propertyDescriptionsToAdd.push({
        description: this.descriptionTextsToAdd[i],
        propertyName: this.templateDetails.templateProperties[i]
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

  /**
   * Sends the finished Order to the API to be added
   *
   * @memberof NewOrderComponent
   */
  addOrder() {
    this.orderService.addOrder(this.orderToAdd).subscribe(
      data => {
        console.log('added order');
        this.alertify.success('Tilføjede bestilling');
        console.log(this.orderToAdd);
      },
      error => {
        console.log('failed to add order');
        this.alertify.error('kunne ikke tilføje bestillingen');
      },
      () => {
        this.router.navigate(['pages/tables/order-table']);
      }
    );
  }
}
