import { Component } from '@angular/core';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemTemplate } from '../../../_models/ItemTemplate';
import { FormControl } from '../../../../../node_modules/@angular/forms';

@Component({
  selector: 'ngx-item-template-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-template-form.component.html',
})
export class ItemTemplateFormComponent {
  templates: ItemTemplate[];
  selectedTemplates: ItemTemplate[];

  constructor(private templateService: ItemTemplateService) {
    this.getTemplates();
  }

  async getTemplates() {
    await this.templateService.getItemTemplates().subscribe(templates => {
      this.templates = templates;
    })
  }
}
