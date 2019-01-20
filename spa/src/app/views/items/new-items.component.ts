import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemService } from '../../_services/item.service';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ItemTemplate } from '../../_models/ItemTemplate';
import { Item } from '../../_models/Item';
import { ItemItemRelation } from '../../_models/ItemItemRelation';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';
import { NewItemSteps } from '../../_enums/NewItemSteps.enum';


@Component({
  templateUrl: './new-items.component.html',
})

export class NewItemComponent implements OnInit {
  currentStep: NewItemSteps = NewItemSteps.ItemTemplate;
  itemTemplates: ItemTemplate[];
  itemsToChooseFromList: ItemItemRelation[];
  missingItems: ItemTemplatePart[];
  itemToAdd: Item = {} as Item;
  currentSelectItem: ItemTemplatePart;


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

  async changeFromSelectItemTemplate() {
    await this.getTemplateDetails();
    if (this.itemToAdd.template.parts === undefined) {
      this.currentStep = NewItemSteps.Info;
    } else {
      this.itemToAdd.parts = [] as ItemItemRelation[];
      this.missingItems = this.itemToAdd.template.parts;
      for ( let part of this.missingItems) {
        part.amount = part.amount * this.itemToAdd.amount;
      }

      this.currentStep = NewItemSteps.Items;
    }
  }

  changeToSelectFromStock(templatePart: ItemTemplatePart) {
    this.itemsToChooseFromList = [] as ItemItemRelation[];
    console.log(templatePart);
    this.currentSelectItem = templatePart;
    this.itemService.getAllInstancesInStock(templatePart.part).subscribe(items => {
      for (let i = 0; i < items.length; i++) {
        this.itemsToChooseFromList.push({part : items[i], amount : 0});
      }
    });
    this.currentStep = NewItemSteps.Stock;
  }

  async getTemplateDetails() {
    await this.templateService.getItemTemplateAsync(this.itemToAdd.template.id).then(itemTemplate => {
      this.itemToAdd.template = itemTemplate;
    });
  }
}
