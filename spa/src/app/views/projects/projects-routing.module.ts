import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewProjectsComponent } from './view-projects.component';
import { DetailsProjectComponent } from './details-project.component';
import { NewProjectComponent } from './new-project.component';

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
      },
      {
        path: 'new',
        component: NewProjectComponent,
        data: {
          title: 'Tilføj projekt'
        }
      },
      {
        path: 'details',
        component: DetailsProjectComponent,
        data: {
          title: 'Detaljer om projekt'
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
