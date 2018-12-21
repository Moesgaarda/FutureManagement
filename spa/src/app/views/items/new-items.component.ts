import { Component } from '@angular/core';
import { Item } from '../../_models/Item';
import { ItemTemplate, UnitType } from '../../_models/ItemTemplate';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemService } from '../../_services/item.service';
import { UserService } from '../../_services/user.service';
import { Observable } from 'rxjs';
import { ItemPropertyDescription } from '../../_models/ItemPropertyDescription';
import { User } from '../../_models/User';
import { ItemItemRelation } from '../../_models/ItemItemRelation';
import { environment } from '../../../environments/environment';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  templateUrl: './new-items.component.html',
})

export class AddItemsComponent {
  itemToAdd: Item = {} as Item;
  templates: ItemTemplate[] = [];
  items: Item[] = [];
  selectedItemParts: Item[] = [];
  selectedItemPartAmounts: number[] = [];
  properties: ItemPropertyDescription[] =  [];
  templateToGet: ItemTemplate = {} as ItemTemplate;
  templateDetails: ItemTemplate = {} as ItemTemplate;
  detailsReady: boolean;
  propertyDescriptionsToAdd: ItemPropertyDescription[] = [] as ItemPropertyDescription[];
  descriptionTextsToAdd: string[] = [] as string[];
  userList: User[] = [];
  itemItemRelations: ItemItemRelation[] = [];
  selectPlacement: string[] = [];
  selectTemplateName: string[] = [];
  selectTextToDisplay: string[] = [];
  itemNamesToShow: Item[] = [];
  baseUrl = environment.spaUrl;

  constructor(private templateService: ItemTemplateService,
  private itemService: ItemService, private userService: UserService, private alertify: AlertifyService) {
    this.getTemplates();
    this.getItems();
    this.getUsers();
  }

  async getTemplates() {
    await this.templateService.getAll().subscribe(templates => {
      this.templates = templates;
    });
  }

  async getTemplateDetails() {
    await this.templateService.getItemTemplate(this.templateToGet.id).subscribe(template => {
      this.templateDetails = template;
    });
    this.detailsReady = true;
  }

  /**
   * ngSelect cannot show the name properly without the mapping made in this method. The mapping removes the
   * name property and replaces it with placement.
   * @memberof AddItemsComponent
   */
  async getItems() {
    await this.itemService.getActiveItems().subscribe(items => {
      this.items = items.map((name) => {
        name.placement = name.template.name + ' - (' + name.placement + ') - Mængde: '
          + name.amount + ' ' + UnitType[name.template.unitType];
        return name;
      });
    });
  }

  async getUsers() {
    await this.userService.getActiveUsers().subscribe(users => {
      this.userList = users;
    });
  }

  /**
   * Calls method to run checks. If they all succeed, descriptions of properties are
   * added in the right format through the for loop, the rest of the properties are
   * given values and user is redirected.
   * @memberof AddItemsComponent
   */
  addItem() {
    let checksPassed = false;
    checksPassed = this.performChecks(checksPassed);

    if (checksPassed) {
      for (let i = 0; i < this.templateDetails.templateProperties.length; i++) {
        this.propertyDescriptionsToAdd.push({
          description: this.descriptionTextsToAdd[i],
          propertyName: this.templateDetails.templateProperties[i],
        });
      }

      this.itemToAdd.parts = this.itemItemRelations;
      this.itemToAdd.properties = this.propertyDescriptionsToAdd;
      this.itemToAdd.template = this.templateDetails;
      this.itemToAdd.isActive = true;
      this.itemService.addItem(this.itemToAdd).subscribe();

      location.href = this.baseUrl + 'items/view';
    }
  }

  performChecks(checkPassed: boolean): boolean {
    checkPassed = this.checkAmountIsNotZero(checkPassed);

    if (checkPassed) {
      checkPassed = this.checkAmountIsFilled(checkPassed);
    }

    if (checkPassed) {
      checkPassed = this.checkStockAboveZero(checkPassed);
    }

    return checkPassed;
  }


  /**
   * Checks to prevent from picking 0. If they pick an amount and then delete it shows as null, so checks for that too.
   * @param {boolean} checkPassed
   * @returns {boolean}
   * @memberof AddItemsComponent
   */
  checkAmountIsNotZero(checkPassed: boolean): boolean {
    for (let i = 0; i < this.selectedItemPartAmounts.length; i++) {
      if (this.selectedItemPartAmounts[i] === 0 || this.selectedItemPartAmounts[i] === null) {
        this.alertify.error('Du kan ikke vælge 0 af en genstand');
        return;
      }
    }

    return checkPassed = true;
  }

  /**
   * If length of itemParts and itemPartsAmounts are not the same, they forgot to fill out a value.
   * @param {boolean} checkPassed
   * @returns {boolean}
   * @memberof AddItemsComponent
   */
  checkAmountIsFilled(checkPassed: boolean): boolean {
    checkPassed = false;
    if (this.selectedItemPartAmounts.length !== this.selectedItemParts.length) {
      this.alertify.error('Du mangler at udfylde mængde på en af dine genstande');
        return;
    }

    return checkPassed = true;
  }

  /**
   * Makes sure you cannot create an item if you do not have enough of the required items.
   * If it passes it adds the items used to the itemItemrelation with amount.
   * @param {boolean} checkPassed
   * @returns {boolean}
   * @memberof AddItemsComponent
   */
  checkStockAboveZero(checkPassed: boolean): boolean {
    checkPassed = false;
    for ( let i = 0; i < this.selectedItemParts.length; i++) {
      for (let j = 0; j < this.items.length; j++) {
        if (this.items[j].id === this.selectedItemParts[i].id && this.items[j].amount < this.selectedItemPartAmounts[i]) {
          this.alertify.error('Lageret har ikke nok af genstand ' + this.items[j].placement);
          return;
        }
      }

      this.itemItemRelations.push({
        amount: this.selectedItemPartAmounts[i],
        partId: this.selectedItemParts[i].id,
      });
    }

    return checkPassed = true;
  }
}
