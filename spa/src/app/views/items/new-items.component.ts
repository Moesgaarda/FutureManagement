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
    await this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
    });
  }

  async getTemplateDetails() {
    await this.templateService.getItemTemplate(this.templateToGet.id).subscribe(template => {
      this.templateDetails = template;
    });
    this.detailsReady = true;
  }

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

  addItem() {
    for ( let i = 0; i < this.selectedItemParts.length; i++) {
      for (let j = 0; j < this.items.length; j++) {
        console.log(this.items[j].id);
        console.log(this.selectedItemParts[i].id);
        if (this.items[j].id === this.selectedItemParts[i].id && this.items[j].amount < this.selectedItemPartAmounts[i]) {
          // this.alertify.error('Lageret har ikke nok af genstand ' + this.items[j].placement);
          return;
        }
      }


      this.itemItemRelations.push({
        amount: this.selectedItemPartAmounts[i],
        partId: this.selectedItemParts[i].id,
      });
    }

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

    // location.href = this.baseUrl + 'items/view';
  }

}
