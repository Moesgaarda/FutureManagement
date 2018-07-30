import { Component } from '@angular/core';
import { ItemTemplateService } from '../../../_services/itemTemplate.service';
import { ItemTemplate } from '../../../_models/ItemTemplate';
import { Observable } from 'rxjs';

@Component({
  selector: 'ngx-item-template-form',
  styleUrls: ['../form-inputs/form-inputs.component.scss'],
  templateUrl: './item-template-form.component.html',
})
export class ItemTemplateFormComponent {
  templates: Observable<ItemTemplate[]>;
  selectedTemplates: ItemTemplate[];

  constructor(private templateService: ItemTemplateService) {
    this.getTemplates();
  }

  async getTemplates() {
    this.templates = await this.templateService.getItemTemplates();
  }
}
