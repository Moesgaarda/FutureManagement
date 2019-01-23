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
import { FileUploadService } from '../../_services/fileUpload.service';
import { OrderStatusEnum } from '../../_enums/OrderStatusEnum.enum';
import { UnitTypeService } from '../../_services/unitType.service';


const URL = environment.apiUrl  + 'FileInput/uploadfiles';
@Component({
  templateUrl: './new-order.component.html'
})
export class NewOrderComponent implements OnInit {
  orderToAdd: Order = {} as Order;
  currentItem: Item = {} as Item;
  templates: ItemTemplate[] = [];
  onOrderPage = true;
  templateToGet: ItemTemplate = {} as ItemTemplate;
  templateDetails: ItemTemplate = {} as ItemTemplate;
  detailsReady = false;
  unitType: UnitType;
  unitTypeList: UnitType[] = [] as UnitType[];
  propertyDescriptionsToAdd: ItemPropertyDescription[] = [] as ItemPropertyDescription[];
  descriptionTextsToAdd: string[] = [] as string[];
  uploader: FileUploadService;
  statuses = Object.keys(OrderStatusEnum);


  constructor(
    private itemTemplateService: ItemTemplateService,
    private orderService: OrderService,
    private alertify: AlertifyService,
    private router: Router,
    private uploaderParameter: FileUploadService,
    private unitTypeService: UnitTypeService
  ) {
    this.templateDetails.templateProperties = [] as ItemPropertyName[];
    this.orderToAdd.products = [] as Item[];
    this.currentItem.template = {} as ItemTemplate;
    this.uploader = uploaderParameter;
    this.uploader.clearQueue();
  }

  async ngOnInit() {
    await this.getTemplates();
    await this.getUnitTypes();
    this.statuses = this.statuses.slice((this.statuses.length / 2), this.statuses.length);
  }

  /**
   * This method is used to switch between page for adding details to order and adding items to order
   *
   * @memberof NewOrderComponent
   */
  changePage() {
    this.onOrderPage = !this.onOrderPage;
    this.detailsReady = false;
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

  async getUnitTypes() {
    await this.unitTypeService.getAll().subscribe(unitTypes => {
      this.unitTypeList = unitTypes;
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
          this.currentItem.template = this.templateDetails;

        },
        error => {
          this.alertify.error('Kunne ikke hente skabelon');
        },
        () => {
          this.detailsReady = true;
        }
      );
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
    this.currentItem.isActive = true;
    this.orderToAdd.products.push(this.currentItem);
    this.changePage();
    this.currentItem = {} as Item;
    this.propertyDescriptionsToAdd = [] as ItemPropertyDescription[];
    this.templateDetails = {} as ItemTemplate;
    this.templateToGet = {} as ItemTemplate;
    this.detailsReady = false;
  }

  /**
   * Sends the finished Order to the API to be added
   *
   * @memberof NewOrderComponent
   */
  async addOrder() {
    if (this.uploader.queuedFiles.length > 0) {
      const fileArray = await this.uploader.upload('OrderFiles');
      this.orderToAdd.files = fileArray;
      this.orderToAdd.fileNames = [];
      for (const file of this.uploader.queuedFiles) {
        this.orderToAdd.fileNames.push(file.name);
      }
    }
    this.orderService.addOrder(this.orderToAdd).subscribe(
      data => {
        this.alertify.success('Tilføjede bestilling');
      },
      error => {
        this.alertify.error('Kunne ikke tilføje bestillingen');
      },
      () => {
        this.router.navigate(['orders/view']);
      }
    );
  }
}
