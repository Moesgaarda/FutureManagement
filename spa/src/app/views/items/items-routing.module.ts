import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewItemsComponent } from './view-items.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Genstande'
    },
    children: [
      {
        path: 'view',
        component: ViewItemsComponent,
        data: {
          title: 'Vis genstande'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemsRoutingModule {}
