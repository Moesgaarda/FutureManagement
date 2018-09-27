import { environment } from '../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { ItemTemplateService } from '../../_services/itemTemplate.service';
import { ItemTemplate, UnitType } from '../../_models/ItemTemplate';
import { ActivatedRoute } from '@angular/router';
import { ItemPropertyName } from '../../_models/ItemPropertyName';
import { Observable } from 'rxjs';
import { ItemTemplatePart } from '../../_models/ItemTemplatePart';

@Component({
  templateUrl: './details-itemTemplate.component.html'
})
export class DetailsItemTemplateComponent implements OnInit {
  unitTypeDisabled: boolean;
  nameDisabled: boolean;
  fileDisabled: boolean;
  descriptionDisabled: boolean;
  template: ItemTemplate;
  newProperty: ItemPropertyName;
  unitTypeEnum: string;
  properties: ItemPropertyName[] = [];
  propertiesToCheck: ItemPropertyName[] = [];
  listToCheck: ItemPropertyName[] = [];
  templates: ItemTemplate[];
  selectedTemplates: ItemTemplate[] = [];
  templatesToGet: ItemTemplatePart[] = [];
  usedTemplates: ItemTemplatePart[] = [];
  templatesToShow: ItemTemplate[];
  unitTypes = Object.keys(UnitType);

  constructor(
    private templateService: ItemTemplateService,
    private route: ActivatedRoute
  ) {
    this.asyncSetup();
  }

  async asyncSetup() {
    await this.loadTemplate();
    await this.loadAllTemplateProperties();
    this.delay(15000);
    this.delay(15000);
    await this.loadTemplates();
    this.delay(15000);
  }

  ngOnInit() {
    this.nameDisabled = true;
    this.fileDisabled = true;
    this.unitTypeDisabled = true;
    this.descriptionDisabled = true;

    // Når man får enum gennem object.keys giver den alle numeriske værdier i første halvdel,
    // og derefter enum strings som anden halvdel. Derfor skal første hjalvdel fjernes.
    this.unitTypes = this.unitTypes.slice(this.unitTypes.length / 2);
  }

  // + caster fra tekst til number
  async loadTemplate() {
    console.log('temp');
    await this.templateService
      .getItemTemplate(+this.route.snapshot.params['id'])
      .subscribe((template: ItemTemplate) => {
        this.template = template;
        this.unitTypeEnum = UnitType[template.unitType];
        this.usedTemplates = template.parts;
        this.propertiesToCheck = template.templateProperties;
        this.templatesToShow = this.getUsedTemplates();
      });
  }

  async loadTemplates() {
    console.log('temps');
    await this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
    });
  }

  async loadAllTemplateProperties() {
    console.log('props');
    await this.templateService
      .getAllTemplateProperties()
      .subscribe(properties => {
        this.properties = properties;
      });
  }

  getUsedTemplates(): ItemTemplate[] {
    console.log('delay');
    for (const get of this.usedTemplates) {
      this.templateService
        .getItemTemplate(get.part.id)
        .subscribe((template: ItemTemplate) => {
          this.selectedTemplates.push(template);
        });
    }
    return this.selectedTemplates;
  }

  checkBox(id) {
    for (const propToCheck of this.propertiesToCheck) {
      if (propToCheck.id === id) {
        return true;
      }
    }
    return false;
  }

  printList() {
    console.log(this.selectedTemplates);
    console.log(this.usedTemplates);
    console.log(this.template);
    console.log(this.templatesToShow);
    console.log(this.properties);
    console.log(this.template.templateProperties);
    console.log(this.template.unitType);
  }

  delay(milliseconds: number) {
    return new Promise<void>(resolve => {
      setTimeout(resolve, milliseconds);
    });
  }

  addProperty() {
    this.templateService
      .addTemplateProperty(this.newProperty)
      .subscribe(prop => {
        this.newProperty = prop;
        this.newProperty.name = '';
      });
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