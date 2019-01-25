
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { TemplatePropertyService } from '../../_services/templateProperty.service';

@Component({
  templateUrl: './edit-templateProperty.component.html'
})
export class EditTemplatePropertyComponent implements OnInit {

  constructor(private templatePropertyService: TemplatePropertyService, private route: ActivatedRoute, private alertify: AlertifyService,
              private router: Router) {}

  TemplateProperty = {} as ItemPropertyName;

  ngOnInit() {
    this.templatePropertyService.getTemplateProperty(+this.route.snapshot.params['id'])
      .subscribe(TemplateProperty => {
        this.TemplateProperty = TemplateProperty;
      });
  }

  Save() {
    console.log(this.TemplateProperty);
        this.templatePropertyService.editTemplateProperty(this.TemplateProperty).subscribe(
          TemplateProperty => {
            this.TemplateProperty = TemplateProperty;
            this.alertify.success('Opdaterede egenskab');
          },
          error => {
            this.alertify.error('Kunne ikke opdatere egenskab');
          }, () => {
            this.router.navigate(['TemplateProperties/view']);
          });
    }
}
