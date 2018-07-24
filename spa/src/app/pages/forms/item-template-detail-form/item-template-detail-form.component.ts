import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../../_models/ItemTemplate';
import { ActivatedRoute } from '../../../../../node_modules/@angular/router';
import { ItemProperty } from '../../../_models/ItemProperty';

@Component({
  selector: 'ngx-item-template-detail-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-template-detail-form.component.html',
})

export class ItemTemplateDetailFormComponent implements OnInit {
  unitTypeDisabled: boolean;
  nameDisabled: boolean;
  fileDisabled: boolean;
  descriptionDisabled: boolean;
  template: ItemTemplate;
  newProperty: ItemProperty;
  unitTypeEnum: string;
  properties: ItemProperty[];
  propertiesToCheck: ItemProperty[];


  constructor(private templateService: ItemTemplateService, private route: ActivatedRoute) {
    this.loadTemplate();
    this.loadTemplateProperties();
   // this.propertyCheck();
  }

  ngOnInit() {
    this.nameDisabled = true;
    this.fileDisabled = true;
    this.unitTypeDisabled = true;
    this.descriptionDisabled = true;
  }

  // + caster fra tekst til number
  async loadTemplate() {
    await this.templateService.getItemTemplate(+this.route.snapshot.params['id'])
    .subscribe((template: ItemTemplate) => {
      this.template = template;
      this.unitTypeEnum = UnitType[template.unitType];
    })
  }

   loadTemplateProperties() {
      this.templateService.getAllTemplateProperties().subscribe(properties => {
      this.properties = properties;
    })
  }

  /*propertyCheck() {
    for (const temp of this.properties) {
      if (this.template.templateProperties.includes(temp)) {
        this.propertiesToCheck.push(temp);
      }
    }
  }*/

  async addProperty() {
    await this.templateService.addTemplateProperty(this.newProperty).subscribe(prop => {
      this.newProperty = prop;
      this.newProperty.name = '';
    })
  }

  enableName() {
    if (this.nameDisabled) {
      this.nameDisabled = false;
    } else {
      // indsæt i db
      this.nameDisabled = true;
    }
  }

  enableunitType() {
    if (this.unitTypeDisabled) {
      this.unitTypeDisabled = false;
    } else {
      // indsæt i db
      this.unitTypeDisabled = true;
    }
  }

  enableDescription() {
    if (this.descriptionDisabled) {
      this.descriptionDisabled = false;
    } else {
      // indsæt i db
      this.descriptionDisabled = true;
    }
  }

  enableFile() {
    if (this.fileDisabled) {
      this.fileDisabled = false;
    } else {
      // indsæt i db
      this.fileDisabled = true;
    }
  }
}
