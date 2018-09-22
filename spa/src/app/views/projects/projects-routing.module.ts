import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewProjectsComponent } from './view-projects.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Projekter'
    },
    children: [
      {
        path: 'view',
        component: ViewProjectsComponent,
        data: {
          title: 'Vis projekter'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectsRoutingModule {}
