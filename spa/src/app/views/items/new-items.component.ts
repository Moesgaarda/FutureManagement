import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemService } from '../../_services/item.service';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ItemTemplate } from '../../_models/ItemTemplate';
import { Item } from '../../_models/Item';
import { ItemItemRelation } from '../../_models/ItemItemRelation';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';

export enum Steps {
  ItemTemplate,
  Items,
  Stock,
  Info
}


@Component({
  templateUrl: './new-items.component.html',
})

export class NewItemComponent implements OnInit {
  currentStep: Steps = Steps.ItemTemplate;
  itemTemplates: ItemTemplate[];
  selectedTemplate: ItemTemplate;
  itemsToChooseFromList: ItemItemRelation[];
  missingItems: ItemTemplatePart[];
  itemToAdd: Item;


  constructor(private templateService: ItemTemplateService,
  private itemService: ItemService, private userService: UserService, private alertify: AlertifyService) {

  }

  ngOnInit() {
    this.getAllItemTemplates();
  }


  async getAllItemTemplates() {
    await this.templateService.getAll().subscribe( itemTemplates => {
      this.itemTemplates = itemTemplates;
    });
  }

  changeFromSelectItemTemplate() {
    if(this.selectedTemplate.parts === undefined) {
      this.currentStep = Steps.Info;
    } else {
      this.missingItems = this.selectedTemplate.parts;
    }
  }

  changeToSelectFromStock(template: ItemTemplate) {
    this.itemService.getAllInstancesInStock(template).subscribe(items => {
      this.itemsInStockToChooseFrom = items;
    });
  }

  async getTemplateDetails() {
    await this.templateService.getItemTemplate(this.selectedTemplate.id).subscribe(itemTemplate => {
      this.selectedTemplate = itemTemplate;
      console.log(this.selectedTemplate);
    });
  }
}
