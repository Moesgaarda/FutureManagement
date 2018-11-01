import { environment } from '../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../_models/ItemTemplate';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';
import { DetailFile } from '../../_models/DetailFile';
import { FileUploadService } from '../../_services/fileUpload.service';

@Component({
  templateUrl: './details-itemTemplate.component.html'
})
export class DetailsItemTemplateComponent implements OnInit {
  isRevisioned = false;
  isDataAvailable = false;
  itemTemplate: ItemTemplate;
  unitTypeEnum: string;
  files: DetailFile[];
  unitTypes = Object.keys(UnitType);
  fileService: FileUploadService;

  constructor(
    private templateService: ItemTemplateService,
    private route: ActivatedRoute,
    private fileUploadService: FileUploadService,
    private router: Router
  ) {
    this.fileService = fileUploadService;
  }

  async ngOnInit() {
    this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
    await this.loadTemplateOnInIt();
  }

  async loadTemplateOnInIt() {
    await this.templateService.getItemTemplateAsync(+this.route.snapshot.params['id'])
      .then(itemTemplate => {
        this.itemTemplate = itemTemplate;
        this.unitTypeEnum = this.unitTypes[itemTemplate.unitType];
        this.isDataAvailable = true;
        if (itemTemplate.revisionedFrom != null) {
          this.isRevisioned = true;
        }
    });
  }

  goToItemTemplateDetail(templateId: number) {
    this.router.navigateByUrl('itemTemplates/details/' + templateId);
  }
  downloadFile(fileDetails: DetailFile){
    this.fileService.download(fileDetails, 'Template');
  }
}
