import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewItemTemplatesComponent } from './view-itemTemplates.component';
import { NewItemTemplateComponent } from './new-itemTemplate.component';
import { DetailsItemTemplateComponent } from './details-itemTemplate.component';
import { ReviseItemTemplateComponent } from './revise-itemTemplate.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Skabeloner',
      roles: ['ItemTemplates_View']
    },
    runGuardsAndResolvers: 'always',
    canActivateChild: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'view'
      },
      {
        path: 'view',
        component: ViewItemTemplatesComponent,
        data: {
          roles: ['ItemTemplates_View'],
          title: 'Vis skabeloner'
        },
      },
      {
        path: 'new',
        component: NewItemTemplateComponent,
        data: {
          roles: ['ItemTemplates_Add'],
          title: 'Tilføj skabelon'
        },
      },
      {
        path: 'details/:id',
        component: DetailsItemTemplateComponent,
        data: {
          roles: ['ItemTemplates_View'],
          title: 'Vis detaljer'
        }
      },
      {
        path: 'revise/:id',
        component: ReviseItemTemplateComponent,
        data: {
          title: 'Revider skabelon',
          roles: ['ItemTemplates_Add']
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemTemplatesRoutingModule {}
