import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TablesComponent } from './tables.component';
import { SmartTableComponent } from './smart-table/smart-table.component';
import { EmployeeTableComponent } from './employee-table/employee-table.component';
import { ItemTableComponent } from './item-table/item-table.component';
import { ItemTemplateTableComponent } from './item-template-table/item-template-table.component';
import { CustomerTableComponent } from './customer-table/customer-table.component';
import { ProjectTableComponent } from './project-table/project-table.component';

const routes: Routes = [{
  path: '',
  component: TablesComponent,
  children: [{
    path: 'smart-table',
    component: SmartTableComponent,
  }, {
    path: 'employee-table',
    component: EmployeeTableComponent,
  }, {
    path: 'item-table',
    component: ItemTableComponent,
  },
  {
    path: 'item-template-table',
    component: ItemTemplateTableComponent,
  }, {
    path: 'customer-table',
    component: CustomerTableComponent,
  }, {
    path: 'project-table',
    component: ProjectTableComponent,
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TablesRoutingModule { }

export const routedComponents = [
  TablesComponent,
  SmartTableComponent,
  EmployeeTableComponent,
  ItemTableComponent,
  ItemTemplateTableComponent,
  CustomerTableComponent,
  ProjectTableComponent,
];