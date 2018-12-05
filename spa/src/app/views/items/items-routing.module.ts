import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewItemsComponent } from './view-items.component';
import { AddItemsComponent } from './new-items.component';
import { DetailsItemComponent } from './details-item.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Genstande'
    },
    canActivate: [AuthGuard],
    children: [
      {
        path: 'view',
        component: ViewItemsComponent,
        data: {
          title: 'Vis genstande',
          roles: ['Items_View']
        }
      },
      {
        path: 'new',
        component: AddItemsComponent,
        data: {
          title: 'Tilføj ny genstand',
          roles: ['Items_Add']
        }
      },
      {
        path: 'details/:id',
        component: DetailsItemComponent,
        data: {
          title: 'Detaljer om genstand',
          roles: ['Items_View']
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
