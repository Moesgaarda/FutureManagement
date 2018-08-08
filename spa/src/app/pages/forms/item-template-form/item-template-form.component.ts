import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../../_models/ItemTemplate';
import { ItemPropertyName } from '../../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../../_models/ItemTemplatePart';
import { FileUploader } from 'ng2-file-upload';

const URL = 'https://localhost:5000/api/FileInput/';

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

  public uploader: FileUploader = new FileUploader({url: URL});
  public hasBaseDropZoneOver: boolean = false;
  public hasAnotherDropZoneOver: boolean = false;

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  public fileOverAnother(e: any): void {
    this.hasAnotherDropZoneOver = e;
  }

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

  onCheckboxChange(prop, event) {
    if (event.target.checked) {
      this.propertiesToAdd.push(prop.id);
    } else {
      for (let i = 0; i < this.properties.length; i++) {
        if (this.propertiesToAdd[i] === prop.id) {
          this.propertiesToAdd.splice(i, 1);
        }
      }
    }
  }
/*
  addExistingTemplateProperty() {
  }*/

  addTemplate() {
    this.templateService.addTemplateProperty(this.templateToAdd);
    console.log('added tempalte!');
    console.log(this.templateToAdd);
  }

  hej() {
    console.log('SelectedTemplates');
    console.log(this.selectedTemplates);
    console.log('partAmounts');
    console.log(this.partAmounts);
    console.log('properties');
    console.log(this.properties);
    // createTemplateToAdd

    /*for (let i = 0; i < this.selectedTemplates.length; i++) {
      this.templatePartsToAdd.push({
        templateId: this.selectedTemplates[i].id,
        amount: this.partAmounts[i],
      });
    }*/

  // this.templateToAdd.parts = this.templatePartsToAdd;
  console.log('propertiesToAdd');
  console.log(this.propertiesToAdd);
  /*for (const prop of this.propertiesToAdd) {
    console.log(prop.id);
  }*/




  this.templateToAdd.templateProperties = this.propertiesToAdd;

  console.log('templateToAdd');
    // this.templateToAdd.unitType = this.unitTypeEnumNumber[this.unitType];
    console.log(this.templateToAdd);

  }

}
