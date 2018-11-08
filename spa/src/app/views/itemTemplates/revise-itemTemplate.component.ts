import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UnitType, ItemTemplate } from '../../_models/ItemTemplate';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { DetailFile } from '../../_models/DetailFile';
import { FileUploadService } from '../../_services/fileUpload.service';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  templateUrl: './revise-itemTemplate.component.html'
})
export class ReviseItemTemplateComponent implements OnInit {
  unitTypes = Object.keys(UnitType);
  isDataAvailable = false;
  templateToRevise: ItemTemplate = {} as ItemTemplate;
  templateToCopy: ItemTemplate = {} as ItemTemplate;
  unitTypeEnum: string;
  unitType: UnitType;
  properties: ItemPropertyName[];
  propertiesToAdd: ItemPropertyName[] = [] as ItemPropertyName[];
  templates: Observable<ItemTemplate[]>;
  selectedTemplates: ItemTemplate[] = [] as ItemTemplate[];
  templateToConvertFromPart: ItemTemplate;
  partAmounts: number[] = [];
  fileService: FileUploadService;
  uploader: FileUploadService;
  propertiesToCheck: ItemPropertyName[] = [];
  templatePartsToAdd: ItemTemplatePart[] = [] as ItemTemplatePart[];

  constructor(private templateService: ItemTemplateService,
              private route: ActivatedRoute,
              private router: Router,
              private uploaderParameter: FileUploadService,
              private alertify: AlertifyService) {
                this.uploader = uploaderParameter;
              }

  async ngOnInit() {
    // unittypes should both enum text and numbers. Dividing by 2 removes numbers.
    this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
    await this.loadTemplateOnInIt();
    await this.loadAllTemplateProperties();
    await this.getTemplates();
    await this.populateSelect();
    // this.putFilesIntoQueue();
  }

  /**
   *A template is copied through the route. Copied template is stored, and revision props are initialized.
   */

  async loadTemplateOnInIt() {
    await this.templateService.getItemTemplateAsync(+this.route.snapshot.params['id'])
      .then(itemTemplate => {
        this.templateToCopy = itemTemplate;
        this.unitTypeEnum = this.unitTypes[itemTemplate.unitType];
        this.templateToRevise.name = itemTemplate.name;
        this.templateToRevise.description = itemTemplate.description;
        this.propertiesToCheck = itemTemplate.templateProperties;
        this.propertiesToAdd = itemTemplate.templateProperties;
        this.isDataAvailable = true;
        this.uploader.queue(itemTemplate.files);
    });
  }

  async loadAllTemplateProperties() {
    await this.templateService.getAllTemplateProperties().subscribe(properties => {
      this.properties = properties;
    });
  }

  async getTemplates() {
    this.templates = await this.templateService.getItemTemplates();
  }

  onCheckboxChange(prop, event) {
    if (event.target.checked) {
      this.propertiesToAdd.push(prop);
    } else {
      for (let i = 0; i < this.properties.length; i++) {
        if (this.propertiesToAdd[i].id === prop.id) {
          this.propertiesToAdd.splice(i, 1);
          break;
        }
      }
    }
  }

  /**
   *ngSelect component needs to be filled with the templates from the copied template.
   *selectedTemplates is the model used by ngSelect, so parts are pushed to this.
   */
  async populateSelect() {
    if (this.isDataAvailable) {
      for (let i = 0; i < this.templateToCopy.parts.length; i++) {
        this.selectedTemplates.push(this.templateToCopy.parts[i].part);
        this.partAmounts.push(this.templateToCopy.parts[i].amount);
      }
    }
  }

  downloadFile(fileDetails: DetailFile) {
    this.fileService.download(fileDetails, 'Template');
  }

  /**
  * The list of properties on the template is compared to all properties so the checkbox can be checked.
  */
  checkBox(id) {
    for (const propToCheck of this.propertiesToCheck) {
      if (propToCheck.id === id) {
        return true;
      }
    }
    return false;
  }

  async addRevision() {
    // selectedTemplates and amounts are pushed to a new array that is formatted correctly for the database.
    for (let i = 0; i < this.selectedTemplates.length; i++) {
      this.templatePartsToAdd.push({
        part: this.selectedTemplates[i],
        templateId: this.selectedTemplates[i].id,
        amount: this.partAmounts[i],
      });
    }

    if (this.uploader.queuedFiles.length > 0) {
      const fileArray = await this.uploader.upload('ItemTemplateFiles');
      this.templateToRevise.files = fileArray;
      this.templateToRevise.fileNames = [];
      for (const file of this.uploader.queuedFiles) {
        this.templateToRevise.fileNames.push(file.name);
      }
    }

    this.templateToRevise.templateProperties = this.propertiesToAdd;
    this.templateToRevise.revisionedFrom = this.templateToCopy;
    this.templateToRevise.unitType = UnitType[this.unitTypeEnum];
    this.templateToRevise.templateProperties = this.propertiesToAdd;
    this.templateToRevise.parts = this.templatePartsToAdd;

    // Revising from new template sets id to 1, otherwise increment
    if (this.templateToCopy.revisionId == null) {
      this.templateToRevise.revisionId = 1;
    } else {
      this.templateToRevise.revisionId = this.templateToCopy.revisionId++;
    }

    this.templateService.addTemplate(this.templateToRevise).subscribe(data => {
      this.alertify.success('Tilføjede revidering af skabelon');
    }, error => {
      this.alertify.error('kunne ikke tilføje revidering');
    }, () => {
      this.router.navigate(['itemTemplates/view']);
    });
  }
}
