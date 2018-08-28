import { Component } from '@angular/core';
import { Item } from '../../../_models/Item';
import { ItemTemplate } from '../../../_models/ItemTemplate';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemService } from '../../../_services/item.service';
import { Observable } from 'rxjs';
import { ItemPropertyDescription } from '../../../_models/ItemPropertyDescription';

@Component({
  selector: 'ngx-item-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-form.component.html',
})
export class ItemFormComponent {
  itemToAdd: Item = {} as Item;
  templates: ItemTemplate[] = [];
  showCreatedBy: boolean;
  items: Observable<Item[]>;
  selectedItemParts: Item[] = [];
  properties: ItemPropertyDescription[] =  [];
  templateToGet: ItemTemplate = {} as ItemTemplate;
  templateDetails: ItemTemplate = {} as ItemTemplate;
  detailsReady: boolean;
  propertyDescriptionsToAdd: ItemPropertyDescription[] = [] as ItemPropertyDescription[];
  descriptionTextsToAdd: string[] = [] as string[];

  constructor(private templateService: ItemTemplateService, private itemService: ItemService) {
    this.getTemplates();
    this.getItems();
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
    this.items = await this.itemService.getActiveItems();
  }

  hej() {

   /* for (let i = 0; i < this.templateDetails.templateProperties.length; i++) {
      this.propertyDescriptionsToAdd.push({
        description: this.descriptionTextsToAdd[i],
        propertyName: this.templateDetails.templateProperties[i],
      });
    }

    this.itemToAdd.properties = this.propertyDescriptionsToAdd;

    this.itemToAdd.parts = this.selectedItemParts;
    console.log(this.templateDetails);
    this.itemToAdd.template = this.templateDetails;*/
    console.log(this.itemToAdd);
  }

  addItem() {
    for (let i = 0; i < this.templateDetails.templateProperties.length; i++) {
      this.propertyDescriptionsToAdd.push({
        description: this.descriptionTextsToAdd[i],
        propertyName: this.templateDetails.templateProperties[i],
      });
    }

    this.itemToAdd.properties = this.propertyDescriptionsToAdd;
    this.itemToAdd.parts = this.selectedItemParts;
    this.itemToAdd.template = this.templateDetails;
    this.itemToAdd.isActive = true;
    this.itemService.addItem(this.itemToAdd).subscribe();
  }

}
