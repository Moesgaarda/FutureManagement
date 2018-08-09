import { Component } from '@angular/core';
import { Item } from '../../../_models/Item';
import { ItemTemplate } from '../../../_models/ItemTemplate';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemService } from '../../../_services/item.service';
import { Observable } from '../../../../../node_modules/rxjs';

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

  async getItems() {
    this.items = await this.itemService.getActiveItems();
  }

  hej() {
    this.itemToAdd.parts = this.selectedItemParts;
    console.log(this.itemToAdd);
  }

  addItem() {
    this.itemService.addItem(this.itemToAdd).subscribe();
  }

}
