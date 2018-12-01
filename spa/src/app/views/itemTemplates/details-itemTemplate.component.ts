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

  /**
   *Creates an instance of DetailsItemTemplateComponent.
   *The services are specified, router brought in and fileService is initialised.
   * @param {ItemTemplateService} templateService
   * @param {ActivatedRoute} route
   * @param {FileUploadService} fileUploadService
   * @param {Router} router
   * @memberof DetailsItemTemplateComponent
   */
  constructor(
    private templateService: ItemTemplateService,
    private route: ActivatedRoute,
    private fileUploadService: FileUploadService,
    private router: Router
  ) {
    this.fileService = fileUploadService;
  }

  /**
   *Calls function to extract template.
   * Unittypes are initially both enum text and numbers. Dividing by 2 removes numbers from dropdown.
   * @memberof DetailsItemTemplateComponent
   */
  async ngOnInit() {
    this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
    await this.loadTemplateOnInIt();
  }

  /**
   *Gets template through the number in the route.
   * itemTemplate property is initilialised with the data from the DB.
   * Unittype number is converted to the string value for display.
   * Data is flagged as available.
   * @memberof DetailsItemTemplateComponent
   */
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

  /**
   * Is passed ID from part of revisionedFrom template.
   * Uses the router to navigate to the proper URL with the id it receives.
   * @param {number} templateId
   * @memberof DetailsItemTemplateComponent
   */
  goToItemTemplateDetail(templateId: number) {
    this.router.navigateByUrl('itemTemplates/details/' + templateId);
  }

  downloadFile(fileDetails: DetailFile) {
    this.fileService.download(fileDetails, 'Template');
  }
}
