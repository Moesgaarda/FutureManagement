import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../_models/ItemTemplate';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { FileUploadService } from '../../_services/fileUpload.service';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import * as _ from 'underscore';

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
  uploader: FileUploadService;
  paginatedPropArray: ItemPropertyName[];
  itemsPerPage = 15;
  currentPage = 1;
  propFilter: string;

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
    this.loadAllTemplateProperties();
    this.uploader = uploaderParameter;
    this.uploader.clearQueue();
  }

  ngOnInit() {
    // unittypes should both enum text and numbers. Dividing by 2 removes numbers.
    this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
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
  async loadAllTemplateProperties() {
    await this.templateService.getAllTemplateProperties().subscribe(properties => {
      this.properties = properties;
      this.paginatedPropArray = properties.slice(0, this.itemsPerPage);
    });
  }


  /**
   * @param {PageChangedEvent} event
   * The event contains pageNumber and itemPerPage. The index of the start item is calculated by previous page number,
   * and the endItem is calculated with the number of the page you are switching to.
   */
  propPageChanged(event: PageChangedEvent): void {
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.paginatedPropArray = this.properties.slice(startItem, endItem);
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

    // Uses the function defined in the service to add. Alertify notifies succes or failure, and user is sent to view table.
    this.templateService.addTemplate(this.templateToAdd).subscribe(data => {
      this.alertify.success('Tilføjede skabelon');
    }, error => {
      this.alertify.error('Kunne ikke tilføje skabelon');
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
      this.loadAllTemplateProperties();
    });
  }
}
