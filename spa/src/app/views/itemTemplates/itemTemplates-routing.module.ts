import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewItemTemplatesComponent } from './view-itemTemplates.component';
import { NewItemTemplateComponent } from './new-itemTemplate.component';
import { DetailsItemTemplateComponent } from './details-itemTemplate.component';
import { ReviseItemTemplateComponent } from './revise-itemTemplate.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Skabeloner'
    },
    children: [
      {
        path: 'view',
        component: ViewItemTemplatesComponent,
        data: {
          title: 'Vis skabeloner'
        }
      },
      {
        path: 'new',
        component: NewItemTemplateComponent,
        data: {
          title: 'Tilføj skabelon'
        }
      },
      {
        path: 'details/:id',
        component: DetailsItemTemplateComponent,
        data: {
          title: 'Vis detaljer'
        }
      },
      {
        path: 'revise/:id',
        component: ReviseItemTemplateComponent,
        data: {
          title: 'Revider skabelon'
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
