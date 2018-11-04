import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UnitType, ItemTemplate } from '../../_models/ItemTemplate';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { DetailFile } from '../../_models/DetailFile';
import { FileUploadService } from '../../_services/fileUpload.service';

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

  constructor(private templateService: ItemTemplateService,
              private route: ActivatedRoute,
              private router: Router,
              private uploaderParameter: FileUploadService) {
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
        this.templateToRevise.description = itemTemplate.description;
        this.isDataAvailable = true;
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


}
