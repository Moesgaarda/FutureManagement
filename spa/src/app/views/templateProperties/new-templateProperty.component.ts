import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import * as _ from 'underscore';
import { ItemPropertyName as TemplateProperty } from '../../_models/ItemPropertyName';
import { AlertifyService } from '../../_services/alertify.service';
import { Router } from '@angular/router';
import { AuthService } from '../../_services/auth.service';
import { TemplatePropertyService } from '../../_services/templateProperty.service';

@Component({
  templateUrl: './new-templateProperty.component.html',
  styles: ['../../../scss/_custom.scss']
})

export class NewTemplatePropertyComponent {
  baseUrl = environment.spaUrl;
  templateProperty = {} as TemplateProperty;

  constructor(private templatePropertyService: TemplatePropertyService, private alertify: AlertifyService, private router: Router) {}

  addTemplateProperty() {
      this.templatePropertyService.addTemplateProperty(this.templateProperty).subscribe(() => {
        this.alertify.success('egenskab blev oprettet');
        this.router.navigate(['templateProperties/view/']);
      }, error => {
        this.alertify.error('Kunne ikke tilføje egenskab');
      });
  }
}
