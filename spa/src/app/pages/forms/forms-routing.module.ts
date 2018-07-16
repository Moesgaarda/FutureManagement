import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FormsComponent } from './forms.component';
import { FormInputsComponent } from './form-inputs/form-inputs.component';
import { FormLayoutsComponent } from './form-layouts/form-layouts.component';
import { ItemTemplateFormComponent } from './item-template-form/item-template-form.component';
import { NewProjectFormComponent } from './new-project-form/new-project-form.component';
import { ItemFormComponent } from './item-form/item-form.component';
import { ItemDetailFormComponent } from './item-detail-form/item-detail-form.component';

const routes: Routes = [{
  path: '',
  component: FormsComponent,
  children: [{
    path: 'inputs',
    component: FormInputsComponent,
  }, {
    path: 'layouts',
    component: FormLayoutsComponent,
  }, {
    path: 'item-template',
    component: ItemTemplateFormComponent,
  }, {
    path: 'item',
    component: ItemFormComponent,
  }, {
    path: 'new-project',
    component: NewProjectFormComponent,
  }, {
    path: 'item-detail',
    component: ItemDetailFormComponent,
  }],
}];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule,
  ],
})
export class FormsRoutingModule {

}

export const routedComponents = [
  FormsComponent,
  FormInputsComponent,
  FormLayoutsComponent,
  ItemTemplateFormComponent,
  ItemFormComponent,
  ItemDetailFormComponent,
  NewProjectFormComponent,
];
