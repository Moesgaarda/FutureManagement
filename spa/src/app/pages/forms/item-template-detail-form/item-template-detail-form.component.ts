import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../../_models/ItemTemplate';
import { ActivatedRoute } from '@angular/router';
import { ItemProperty } from '../../../_models/ItemProperty';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../../_models/ItemTemplatePart';

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
  properties: ItemProperty[] = [];
  propertiesToCheck: ItemProperty[] = [];
  listToCheck: ItemProperty[] = [];
  templates: Observable<ItemTemplate[]>;
  selectedTemplates: ItemTemplate[] = [];
  templatesToGet: ItemTemplatePart[] = [];
  usedTemplates: ItemTemplatePart[] = [];



  constructor(private templateService: ItemTemplateService, private route: ActivatedRoute) {
    this.asyncSetup();
  }

  async asyncSetup() {
    await this.loadTemplate();
    this.delay(15000);
    await this.loadAllTemplateProperties();
    this.delay(15000);
    await this.loadTemplates();
    this.delay(15000);
  }

  ngOnInit() {

    this.nameDisabled = true;
    this.fileDisabled = true;
    this.unitTypeDisabled = true;
    this.descriptionDisabled = true;
  }

  // + caster fra tekst til number
  async loadTemplate() {
    console.log('temp');
    await this.templateService.getItemTemplate(+this.route.snapshot.params['id'])
    .subscribe((template: ItemTemplate) => {
      this.template = template;
      this.unitTypeEnum = UnitType[template.unitType];
      this.usedTemplates = template.parts;
      this.getUsedTemplates();
    })
  }

  async loadTemplates() {
    console.log('temps');
    this.templates = await this.templateService.getItemTemplates();
  }

   loadAllTemplateProperties() {
    console.log('proprs');
      this.templateService.getAllTemplateProperties().subscribe(properties => {
      this.properties = properties;
    })
  }

  propertyCheck() {
    for (const prop of this.template.templateProperties) {
      const listToCheck = this.properties;
      listToCheck.push(prop);
    }
  }

  async getUsedTemplates() {
    console.log('delay');
    for (const get of this.usedTemplates)
    await this.templateService.getItemTemplate(get.part.id)
    .subscribe((template: ItemTemplate) => {
      this.selectedTemplates.push(template);
    })
  }

  printList() {
    console.log(this.selectedTemplates);
    console.log(this.usedTemplates);
  }

  async delay(milliseconds: number) {
    return new Promise<void>(resolve => {
        setTimeout(resolve, milliseconds);
    });
}

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
