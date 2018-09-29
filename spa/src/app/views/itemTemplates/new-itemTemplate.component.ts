import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../_models/ItemTemplate';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { FileUploadService } from '../../_services/fileUpload.service';

const URL = environment.apiUrl  + 'FileInput/uploadfiles';

@Component({
  templateUrl: './new-itemTemplate.component.html',
})
export class NewItemTemplateComponent implements OnInit {
  templates: Observable<ItemTemplate[]>;
  selectedTemplates: ItemTemplate[] = [] as ItemTemplate[];
  unitTypes = Object.keys(UnitType);
  properties: ItemPropertyName[];
  templateToAdd: ItemTemplate = {} as ItemTemplate;
  unitType: UnitType;
  unitTypeEnumNumber = UnitType;
  templatePartsToAdd: ItemTemplatePart[] = [] as ItemTemplatePart[];
  partAmounts: number[] = [];
  propertiesToAdd: ItemPropertyName[] = [] as ItemPropertyName[];
  propToAddToDb: ItemPropertyName = {} as ItemPropertyName;
  fileNamesToAdd: string;
  constructor(private templateService: ItemTemplateService, private router: Router,
     private alertify: AlertifyService, private uploader: FileUploadService) {
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
    });
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

  async addTemplate() {
    console.log('added template!');
    console.log(this.properties);
    console.log('API URL = ' + environment.apiUrl);

    for (let i = 0; i < this.selectedTemplates.length; i++) {
      this.templatePartsToAdd.push({
        part: this.selectedTemplates[i],
        templateId: this.selectedTemplates[i].id,
        amount: this.partAmounts[i],
      });
    }
    if (this.uploader.queuedFiles.length > 0) {
      const fileArray = await this.uploader.upload('ItemTemplateFiles');
      this.templateToAdd.files = fileArray;
      this.templateToAdd.fileNames = [];
      for (const file of this.uploader.queuedFiles) {
        this.templateToAdd.fileNames.push(file.name);
      }
    }
    console.log(this.templateToAdd.files);
    this.templateToAdd.parts = this.templatePartsToAdd;
    this.templateToAdd.unitType = this.unitType;
    this.templateToAdd.templateProperties = this.propertiesToAdd;

    console.log(this.templateToAdd);

    this.templateService.addTemplate(this.templateToAdd).subscribe(data => {
      console.log('added template');
      this.alertify.success('Tilføjede skabelon');
    }, error => {
      console.log('failed to add template');
      this.alertify.error('kunne ikke tilføje skabelon');
    }, () => {
      this.router.navigate(['pages/tables/item-template-table']);
    });
  }

  async addTemplateProperty() {
    await this.templateService.addTemplateProperty(this.propToAddToDb).subscribe();
    this.loadAllTemplateProperties();
  }
}
