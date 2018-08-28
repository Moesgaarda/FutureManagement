import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FormsComponent } from './forms.component';
import { FormInputsComponent } from './form-inputs/form-inputs.component';
import { FormLayoutsComponent } from './form-layouts/form-layouts.component';
import { ItemTemplateFormComponent } from './item-template-form/item-template-form.component';
import { NewProjectFormComponent } from './new-project-form/new-project-form.component';
import { ItemFormComponent } from './item-form/item-form.component';
import { ItemDetailFormComponent } from './item-detail-form/item-detail-form.component';
import { OrderDetailFormComponent } from './order-detail-form/order-detail-form.component';
import { ItemTemplateDetailFormComponent } from './item-template-detail-form/item-template-detail-form.component';
import { UserDetailFormComponent } from './user-detail-form/user-detail-form.component';
import { OrderFormComponent } from './order-form/order-form.component';

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
    path: 'item-detail/:id',
    component: ItemDetailFormComponent,
  }, {
    path: 'order-detail',
    component: OrderDetailFormComponent,
  }, {
    path: 'order',
    component: OrderFormComponent,
  }, {
    path: 'item-template-detail/:id',
    component: ItemTemplateDetailFormComponent,
  }, {
    path: 'user-detail/:id',
    component: UserDetailFormComponent,
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
  OrderDetailFormComponent,
  OrderFormComponent,
  ItemTemplateDetailFormComponent,
  UserDetailFormComponent,
];
