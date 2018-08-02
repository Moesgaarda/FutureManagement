import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../../_models/ItemTemplate';
import { ItemPropertyName } from '../../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../../_models/ItemTemplatePart';

@Component({
  selector: 'ngx-item-template-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-template-form.component.html',
})
export class ItemTemplateFormComponent implements OnInit {
  templates: Observable<ItemTemplate[]>;
  selectedTemplates: ItemTemplate[];
  unitTypes = Object.keys(UnitType);
  properties: ItemPropertyName[];
  templateToAdd: ItemTemplate = {} as ItemTemplate;
  unitType: UnitType;
  unitTypeEnumNumber = UnitType;
  templatePartsToAdd: ItemTemplatePart[] = [];
  partAmounts: number[] = [];
  propertiesToAdd: ItemPropertyName[] = [];

  constructor(private templateService: ItemTemplateService) {
    this.getTemplates();
    this.loadAllTemplateProperties();
  }

  ngOnInit() {
    this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
  }

  async getTemplates() {
    this.templates = await this.templateService.getItemTemplates();
  }

  async loadAllTemplateProperties() {
    await this.templateService.getAllTemplateProperties().subscribe(properties => {
      this.properties = properties;
    })
  }

  addTemplate() {
    // this.templateService.
  }

  hej() {
    console.log(this.selectedTemplates);
    console.log(this.partAmounts);
    console.log(this.properties);
    // createTemplateToAdd

    /*for (let i = 0; i < this.selectedTemplates.length; i++) {
      this.templatePartsToAdd.push({
        templateId: this.selectedTemplates[i].id,
        amount: this.partAmounts[i],
      });
    }*/

  // this.templateToAdd.parts = this.templatePartsToAdd;

  console.log(this.propertiesToAdd);
  /*for (const prop of this.propertiesToAdd) {
    console.log(prop.id);
  }*/




  this.templateToAdd.templateProperties = this.propertiesToAdd;


    // this.templateToAdd.unitType = this.unitTypeEnumNumber[this.unitType];
    console.log(this.templateToAdd);

  }

}
