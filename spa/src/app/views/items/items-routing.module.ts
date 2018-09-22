import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewItemsComponent } from './view-items.component';
import { AddItemsComponent } from './new-items.component';

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
      },
      {
        path: 'new',
        component: AddItemsComponent,
        data: {
          title: 'Tilføj ny genstand'
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
