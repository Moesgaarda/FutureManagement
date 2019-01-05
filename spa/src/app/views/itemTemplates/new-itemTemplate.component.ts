import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemTemplate } from '../../_models/ItemTemplate';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { FileUploadService } from '../../_services/fileUpload.service';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import * as _ from 'underscore';
import { ItemTemplateCategory } from '../../_models/ItemTemplateCategory';
import { UnitType } from '../../_models/UnitType';

const URL = environment.apiUrl  + 'FileInput/uploadfiles';

@Component({
  templateUrl: './new-itemTemplate.component.html',
})

export class NewItemTemplateComponent implements OnInit {
  templates: Observable<ItemTemplate[]>;
  selectedTemplates: ItemTemplate[] = [] as ItemTemplate[];
  properties: ItemPropertyName[];
  templateToAdd: ItemTemplate = {} as ItemTemplate;
  unitType: UnitType = {} as UnitType;
  unitTypeList: UnitType[] = [] as UnitType[];
  unitTypeToAddToDb: UnitType = {} as UnitType;
  templatePartsToAdd: ItemTemplatePart[] = [] as ItemTemplatePart[];
  partAmounts: number[] = [];
  propertiesToAdd: ItemPropertyName[] = [] as ItemPropertyName[];
  propToAddToDb: ItemPropertyName = {} as ItemPropertyName;
  fileNamesToAdd: string;
  uploader: FileUploadService;
  itemsPerPage = 15;
  currentPage = 1;
  propFilter: string;
  category: ItemTemplateCategory = {} as ItemTemplateCategory;
  categoryList: ItemTemplateCategory[] = [] as ItemTemplateCategory[];
  categoryToAddToDb: ItemTemplateCategory = {} as ItemTemplateCategory;

  /**
   * @param {ItemTemplateService} templateService
   * @param {Router} router
   * @param {AlertifyService} alertify
   * @param {FileUploadService} uploaderParameter
   * Sets up the different services, calls functions to load templates and properties.
   */
  constructor(private templateService: ItemTemplateService, private router: Router,
     private alertify: AlertifyService, private uploaderParameter: FileUploadService) {
    this.getTemplates();
    this.getTemplateProperties();
    this.getTemplateCategories();
    this.getUnitTypes();
    this.uploader = uploaderParameter;
    this.uploader.clearQueue();
  }

  ngOnInit() {
    // Properties array is sorted alphabetically through underscorejs
    _.sortBy(this.properties, 'name');
  }

  /**
   *Uses the function defined in the templateService to load into templates array of observables.
   */
  async getTemplates() {
    this.templates = await this.templateService.getAll();
  }

  /**
   *Loads all properties and subscrubes since properties array is not an observable.
   */
  async getTemplateProperties() {
    await this.templateService.getTemplateProperties().subscribe(properties => {
      this.properties = properties;
    });
  }

  async getTemplateCategories() {
    await this.templateService.getTemplateCategories().subscribe(categories => {
      this.categoryList = categories;
    });
  }

  async getUnitTypes() {
    await this.templateService.getUnitTypes().subscribe(unitTypes => {
      this.unitTypeList = unitTypes;
    });
  }

  /**
   * @param {*} prop
   * @param {*} event
   * prop is the property represented by the checkbox, event is the act of checking or unchecking.
   * Upon check it simply adds to the array, if unchecked it searches the array and splices that one prop out.
   */
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

  async addTemplate() {
    // SelectedTemplates is of type ItemTemplate, templatePartsToAdd are parts. Takes the necessary information from
    // the ItemTemplate and pushes to the Part array.
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

    this.templateToAdd.parts = this.templatePartsToAdd;
    this.templateToAdd.unitType = this.unitType;
    this.templateToAdd.templateProperties = this.propertiesToAdd;
    this.templateToAdd.category = this.category;
    this.templateToAdd.created = new Date();

    // Uses the function defined in the service to add. Alertify notifies succes or failure, and user is sent to view table.
    this.templateService.addTemplate(this.templateToAdd).subscribe(data => {
      this.alertify.success('Tilføjede skabelon');
    }, error => {
      this.alertify.error('Kunne ikke tilføje skabelon');
      console.log(error.message);
    }, () => {
      this.router.navigate(['itemTemplates/view']);
    });
  }

  async addTemplateProperty() {
    // Checks if the name of the property being added already exists in the database.
    // Converts to lowercase, so multiples do not exist.
    for (let i = 0; i < this.properties.length; i++) {
      if (this.properties[i].name.toLowerCase() === this.propToAddToDb.name.toLowerCase()) {
        this.alertify.error('En egenskab med dette navn findes allerede!');
        return;
      }
    }

    // It is added if not found in the DB.
    await this.templateService.addTemplateProperty(this.propToAddToDb).subscribe( () => {
      this.alertify.success('Tiføjede ' + this.propToAddToDb.name +  '!');
      this.getTemplateProperties();
    });
  }

  async addTemplateCategory() {
    for (let i = 0; i < this.categoryList.length; i++) {
      if (this.categoryList[i].name.toLowerCase() === this.categoryToAddToDb.name.toLowerCase()) {
        this.alertify.error('En kategori med dette navn findes allerede!');
        return;
      }
    }

    await this.templateService.addTemplateCategory(this.categoryToAddToDb).subscribe( () => {
      this.alertify.success('Tiføjede ' + this.categoryToAddToDb.name +  '!');
      this.getTemplateCategories();
    });
  }

  async addUnitType() {
    for (let i = 0; i < this.unitTypeList.length; i++) {
      if (this.unitTypeList[i].name.toLowerCase() === this.unitTypeToAddToDb.name.toLowerCase()) {
        this.alertify.error('En mængdeenhed med dette navn findes allerede!');
        return;
      }
    }

    await this.templateService.addUnitType(this.unitTypeToAddToDb).subscribe( () => {
      this.alertify.success('Tiføjede ' + this.unitTypeToAddToDb.name +  '!');
      this.getUnitTypes();
    });
  }

  checkBox(id) {
    for (const propToCheck of this.propertiesToAdd) {
      if (propToCheck.id === id) {
        return true;
      }
    }
    return false;
  }
}
