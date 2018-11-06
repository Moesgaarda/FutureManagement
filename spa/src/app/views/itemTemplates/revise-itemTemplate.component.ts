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
    this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
    await this.loadTemplateOnInIt();
    await this.loadAllTemplateProperties();
    await this.getTemplates();
    await this.populateSelect();
    // this.putFilesIntoQueue();
  }

  async loadTemplateOnInIt() {
    await this.templateService.getItemTemplateAsync(+this.route.snapshot.params['id'])
      .then(itemTemplate => {
        this.templateToCopy = itemTemplate;
        this.unitTypeEnum = this.unitTypes[itemTemplate.unitType];
        this.templateToRevise = itemTemplate;
        this.propertiesToCheck = itemTemplate.templateProperties;
        this.isDataAvailable = true;
    });
    console.log(this.templateToRevise);
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
        if (this.propertiesToAdd[i] === prop) {
          this.propertiesToAdd.splice(i, 1);
        }
      }
    }
  }

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

  putFilesIntoQueue() {
  }

  checkBox(id) {
    for (const propToCheck of this.propertiesToCheck) {
      if (propToCheck.id === id) {
        return true;
      }
    }
    return false;
  }

  async addRevision() {
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

    this.templateToRevise.revisionedFrom = this.templateToCopy;
    this.templateToRevise.unitType = UnitType[this.unitTypeEnum];
    this.templateToRevise.templateProperties = this.propertiesToAdd;

    this.templateService.addTemplate(this.templateToRevise).subscribe(data => {
      this.alertify.success('Tilføjede revidering af skabelon');
    }, error => {
      this.alertify.error('kunne ikke tilføje revidering');
    }, () => {
      this.router.navigate(['itemTemplates/view']);
    });
  }
}
