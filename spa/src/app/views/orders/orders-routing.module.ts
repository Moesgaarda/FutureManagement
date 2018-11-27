import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewOrdersComponent } from './view-orders.component';
import { DetailsOrderComponent } from './details-order.component';
import { NewOrderComponent } from './new-order.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Bestillinger',
      roles: ['ItemTempaltes_View']
    },
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'view',
        component: ViewOrdersComponent,
        data: {
          title: 'Vis bestillinger'
        }
      },
      {
        path: 'details/:id',
        component: DetailsOrderComponent,
        data: {
          title: 'Detaljer for bestilling'
        }
      },
      {
        path: 'new',
        component: NewOrderComponent,
        data: {
          title: 'Ny bestilling'
        }
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule {}
