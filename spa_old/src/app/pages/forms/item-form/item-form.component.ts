import { Component } from '@angular/core';
import { Item } from '../../../_models/Item';
import { ItemTemplate, UnitType } from '../../../_models/ItemTemplate';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemService } from '../../../_services/item.service';
import { UserService } from '../../../_services/user.service';
import { Observable } from 'rxjs';
import { ItemPropertyDescription } from '../../../_models/ItemPropertyDescription';
import { User } from '../../../_models/User';
import { ItemItemRelation } from '../../../_models/ItemItemRelation';

@Component({
  selector: 'ngx-item-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-form.component.html',
})
export class ItemFormComponent {
  itemToAdd: Item = {} as Item;
  templates: ItemTemplate[] = [];
  showCreatedBy: boolean;
  items: Item[] = [];
  selectedItemParts: Item[] = [];
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

  constructor(private templateService: ItemTemplateService,
  private itemService: ItemService, private userService: UserService) {
    this.getTemplates();
    this.getItems();
    this.getUsers();
    this.showCreatedBy = false;
  }

  async getTemplates() {
    await this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
    })

  }

  async getTemplateDetails() {
    await this.templateService.getItemTemplate(this.templateToGet.id).subscribe(template => {
      this.templateDetails = template;
    })
    this.detailsReady = true;
  }

  async getItems() {
    await this.itemService.getActiveItems().subscribe(items => {
      this.items = items.map((name) => {
        name.placement = name.template.name + ' (' + name.placement + ') - '
          + name.amount + ' ' + UnitType[name.template.unitType];
        return name;
      });
    })
  }

  async getUsers() {
    await this.userService.getActiveUsers().subscribe(users => {
      this.userList = users;
    });
  }

  addItem() {
   for (let i = 0; i < this.templateDetails.templateProperties.length; i++) {
      this.propertyDescriptionsToAdd.push({
        description: this.descriptionTextsToAdd[i],
        propertyName: this.templateDetails.templateProperties[i],
      });
    }

    for ( let i = 0; i < this.selectedItemParts.length; i++) {
      this.itemItemRelations.push({
        amount: this.selectedItemParts[i].amount,
        partId: this.selectedItemParts[i].id,
      });
    }

    this.itemToAdd.parts = this.itemItemRelations;

    this.itemToAdd.properties = this.propertyDescriptionsToAdd;
    this.itemToAdd.template = this.templateDetails;
    this.itemToAdd.isActive = true;
    this.itemService.addItem(this.itemToAdd).subscribe();
  }

}
