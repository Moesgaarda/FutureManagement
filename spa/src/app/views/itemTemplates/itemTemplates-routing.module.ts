import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewItemTemplatesComponent } from './view-itemTemplates.component';

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
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemTemplatesRoutingModule {}
