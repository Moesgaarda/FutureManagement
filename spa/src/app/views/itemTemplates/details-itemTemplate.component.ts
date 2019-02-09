import { environment } from '../../../environments/environment';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemTemplate } from '../../_models/ItemTemplate';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { Observable, Subscription } from 'rxjs';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';
import { DetailFile } from '../../_models/DetailFile';
import { FileUploadService } from '../../_services/fileUpload.service';
import { UnitType } from '../../_models/UnitType';
import { AuthService } from '../../_services/auth.service';

@Component({
  templateUrl: './details-itemTemplate.component.html'
})
export class DetailsItemTemplateComponent implements OnInit, OnDestroy {
  isRevisioned = false;
  isDataAvailable = false;
  itemTemplate: ItemTemplate;
  files: DetailFile[];
  fileService: FileUploadService;
  subscription: Subscription;

  constructor(
    private templateService: ItemTemplateService,
    private route: ActivatedRoute,
    private fileUploadService: FileUploadService,
    private router: Router,
    public authService: AuthService
  ) {
    this.fileService = fileUploadService;
  }

  async ngOnInit() {
    this.subscription = this.route.params.subscribe(
      (params: Params) => {
        this.loadTemplateOnInIt(params);
      }
    );
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  async loadTemplateOnInIt(params: Params) {
    await this.templateService.getItemTemplateAsync(params['id'])
      .then(itemTemplate => {
        this.itemTemplate = itemTemplate;

        this.isDataAvailable = true;
        if (itemTemplate.revisionedFrom != null) {
          this.isRevisioned = true;
        }
    });
  }

  goToItemTemplateDetail(templateId: number) {
    this.router.navigateByUrl('itemTemplates/details/' + templateId);
  }
  downloadFile(fileDetails: DetailFile) {
    this.fileService.download(fileDetails, 'Template');
  }

  goToRevisionTemplate(){
    this.router.navigate(['itemTemplates/revise/' + this.itemTemplate.id]);
  }
}
