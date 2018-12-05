import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewProjectsComponent } from './view-projects.component';
import { DetailsProjectComponent } from './details-project.component';
import { NewProjectComponent } from './new-project.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Projekter'
    },
    canActivate: [AuthGuard],
    children: [
      {
        path: 'view',
        component: ViewProjectsComponent,
        data: {
          title: 'Vis projekter',
          roles: ['Project_View']
        }
      },
      {
        path: 'new',
        component: NewProjectComponent,
        data: {
          title: 'Tilføj projekt',
          roles: ['Project_Add']
        }
      },
      {
        path: 'details/:id',
        component: DetailsProjectComponent,
        data: {
          title: 'Detaljer om projekt',
          roles: ['Project_View']
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
