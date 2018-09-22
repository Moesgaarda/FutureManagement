import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewProjectsComponent } from './view-projects.component';

import { ProjectsRoutingModule } from './projects-routing.module';

@NgModule({
  imports: [
    ProjectsRoutingModule,
    Ng2SmartTableModule,
  ],
  declarations: [ ViewProjectsComponent ]
})
export class ProjectsModule { }
