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
import { ItemPropertyDescription } from '../../_models/ItemPropertyDescription';
import { Router } from '@angular/router';


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
    private router: Router, private itemService: ItemService, private userService: UserService, private alertify: AlertifyService) {

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
      this.changeToInfo();
    } else {
      this.itemToAdd.parts = [] as ItemItemRelation[];
      this.missingItems = this.itemToAdd.template.parts;
      for (const part of this.missingItems) {
        part.amount = part.amount * this.itemToAdd.amount;
      }

      if (this.missingItems.length === 0){
        this.currentStep = NewItemSteps.Info;
      } else {
        this.currentStep = NewItemSteps.Items;
      }
    }
  }

  changeToSelectFromStock(templatePart: ItemTemplatePart) {
    this.itemsToChooseFromList = [] as ItemItemRelation[];
    this.currentSelectItem = templatePart;
    this.itemService.getAllInstancesInStock(templatePart.part).subscribe(items => {
      for (let i = 0; i < items.length; i++) {
        this.itemsToChooseFromList.push({part : items[i], amount : 0});
      }
    });
    this.currentStep = NewItemSteps.Stock;
  }

  changeFromStockToSelect() {
    let amountChoosen = 0;
    const itemsChoosen: ItemItemRelation[] = [] as ItemItemRelation[];
    for (const item of this.itemsToChooseFromList) {
      if (item.amount > item.part.amount) {
        this.alertify.error('Der er kun ' + item.part.amount + ' på placering: ' + item.part.placement);
        break;
      } else {
        const amountChoosenAsInt: number = parseInt(amountChoosen.toString(), 0);
        const itemAmountAsInt: number = parseInt(item.amount.toString(), 0);
        amountChoosen = amountChoosenAsInt + itemAmountAsInt;
        if (item.amount > 0) {
          itemsChoosen.push(item);
        }
      }
    }
    if (amountChoosen !== this.currentSelectItem.amount) {
      this.alertify.error('Du har valgt ' + amountChoosen + ' men du skulle vælge ' + this.currentSelectItem.amount);
    } else {
      this.itemToAdd.parts = this.itemToAdd.parts.concat(itemsChoosen);
      const removed = this.missingItems.splice(this.missingItems.indexOf(this.currentSelectItem), 1);
      this.currentStep = NewItemSteps.Items;
    }
  }
  changeToInfo() {
    this.itemToAdd.properties = [] as ItemPropertyDescription [];
    for (const property of this.itemToAdd.template.templateProperties) {
      this.itemToAdd.properties.push({description: '' , propertyName: property});
    }
    this.currentStep = NewItemSteps.Info;
  }
  addItem() {
    this.itemToAdd.isActive = true;
    this.itemService.addItem(this.itemToAdd).subscribe(
      data => {
        this.alertify.success('Tilføjede genstand til lageret');
      },
      error => {
        this.alertify.error('Kunne ikke tilføje genstand');
      },
      () => {
        this.router.navigate(['items/view']);
      }
    );
  }

  async getTemplateDetails() {
    await this.templateService.getItemTemplateAsync(this.itemToAdd.template.id).then(itemTemplate => {
      this.itemToAdd.template = itemTemplate;
    });
  }
}
