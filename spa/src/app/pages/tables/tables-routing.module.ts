import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TablesComponent } from './tables.component';
import { EmployeeTableComponent } from './employee-table/employee-table.component';
import { ActiveItemTableComponent } from './active-item-table/active-item-table.component';
import { InactiveItemTableComponent } from './inactive-item-table/inactive-item-table.component';
import { ItemTableComponent } from './item-table/item-table.component';
import { ItemTemplateTableComponent } from './item-template-table/item-template-table.component';
import { CustomerTableComponent } from './customer-table/customer-table.component';
import { ProjectTableComponent } from './project-table/project-table.component';
import { EventLogTableComponent } from './event-log-table/event-log-table.component';

const routes: Routes = [{
  path: '',
  component: TablesComponent,
  children: [{
    path: 'employee-table',
    component: EmployeeTableComponent,
  }, {
    path: 'active-item-table',
    component: ActiveItemTableComponent,
  }, {
    path: 'inactive-item-table',
    component: InactiveItemTableComponent,
  }, {
    path: 'item-table',
    component: ItemTableComponent,
  }, {
    path: 'item-template-table',
    component: ItemTemplateTableComponent,
  }, {
    path: 'customer-table',
    component: CustomerTableComponent,
  }, {
    path: 'project-table',
    component: ProjectTableComponent,
  }, {
    path: 'event-log-table',
    component: EventLogTableComponent,
  }],
  }]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TablesRoutingModule { }

export const routedComponents = [
  TablesComponent,
  EmployeeTableComponent,
  ActiveItemTableComponent,
  ItemTemplateTableComponent,
  CustomerTableComponent,
  ProjectTableComponent,
  ItemTableComponent,
  InactiveItemTableComponent,
  EventLogTableComponent,
];
