import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../../_models/ItemTemplate';
import { ItemPropertyName } from '../../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../../_models/ItemTemplatePart';
import { FileUploader } from 'ng2-file-upload';
import { environment } from '../../../../environments/environment'

const URL = environment.apiUrl  + 'FileInput/uploadfiles';

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
  propertiesToAdd: ItemPropertyName[] = [] as ItemPropertyName[];
  propToAddToDb: ItemPropertyName = {} as ItemPropertyName;

  public uploader: FileUploader = new FileUploader({url: URL});

  constructor(private templateService: ItemTemplateService) {
    this.getTemplates();
    this.loadAllTemplateProperties();
  }

  ngOnInit() {
    this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);

    this.uploader.onCompleteItem = (item: any, response: any, status: any, headers: any) => {

      console.log('ImageUpload:uploaded:', item, status);
  };
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
      this.propertiesToAdd.push(prop);
    } else {
      for (let i = 0; i < this.properties.length; i++) {
        if (this.propertiesToAdd[i] === prop) {
          this.propertiesToAdd.splice(i, 1);
        }
      }
    }
  }

  addExistingTemplateProperty() {
  }

  addTemplate() {
    console.log('added tempalte!');
    console.log(this.templateToAdd);

    for (let i = 0; i < this.selectedTemplates.length; i++) {
      this.templatePartsToAdd.push({
        part: this.selectedTemplates[i],
        templateId: this.selectedTemplates[i].id,
        amount: this.partAmounts[i],
      });
    }

    this.templateToAdd.parts = this.templatePartsToAdd;
    // this.templateToAdd.unitType = this.unitTypeEnumNumber[this.unitType];
    this.templateToAdd.templateProperties = this.propertiesToAdd;

    this.templateService.addTemplate(this.templateToAdd).subscribe();
  }

  async addTemplateProperty() {
    await this.templateService.addTemplateProperty(this.propToAddToDb).subscribe();
    this.loadAllTemplateProperties();
  }
}
