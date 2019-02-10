import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewProjectsComponent } from './view-projects.component';
import { NewProjectComponent } from './new-project.component';
import { DetailsProjectComponent } from './details-project.component';

import { ProjectsRoutingModule } from './projects-routing.module';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';


@NgModule({
  imports: [
    ProjectsRoutingModule,
    Ng2SmartTableModule,
    Ng2SmartTableModule,
    FormsModule,
    CommonModule,
    NgSelectModule
  ],
  declarations: [
    ViewProjectsComponent,
    NewProjectComponent,
    DetailsProjectComponent ]
})
export class ProjectsModule { }
