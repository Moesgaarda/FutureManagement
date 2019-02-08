import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ViewItemsComponent} from './view-items.component';
import {NewItemComponent} from './new-items.component';
import {DetailsItemComponent} from './details-item.component';
import {AuthGuard} from '../../_guards/auth.guard';
import {EditItemComponent} from './edit-item.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Genstande'
    },
    canActivateChild: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'view'
      },
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
        component: NewItemComponent,
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
      },
      {
        path: 'edit/:id',
        component: EditItemComponent,
        data: {
          title: 'Rediger genstand',
          roles: ['Items_Edit']
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemsRoutingModule {
}
