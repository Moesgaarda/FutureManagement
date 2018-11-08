import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewItemTemplatesComponent } from './view-itemTemplates.component';
import { NewItemTemplateComponent } from './new-itemTemplate.component';
import { DetailsItemTemplateComponent } from './details-itemTemplate.component';

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
          title: 'Vis skabeloner',
          roles: ['ItemTemplates_View']
        }
      },
      {
        path: 'new',
        component: NewItemTemplateComponent,
        data: {
          title: 'Tilføj skabelon',
          roles: ['ItemTemplates_Add']
        }
      },
      {
        path: 'details/:id',
        component: DetailsItemTemplateComponent,
        data: {
          title: 'Vis detaljer',
          roles: ['ItemTemplates_View']
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
