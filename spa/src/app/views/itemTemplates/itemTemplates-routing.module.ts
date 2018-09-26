import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewItemTemplatesComponent } from './view-itemTemplates.component';
import { NewItemTemplateComponent } from './new-itemTemplate.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Genstande'
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
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemTemplatesRoutingModule {}
