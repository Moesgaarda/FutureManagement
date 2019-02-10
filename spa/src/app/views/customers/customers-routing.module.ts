import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewCustomersComponent } from './view-customers.component';
import { NewCustomerComponent } from './new-customer.component';
import { DetailsCustomerComponent } from './details-customer.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Kunder'
    },
    canActivateChild: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'view'
      },
      {
        path: 'view',
        component: ViewCustomersComponent,
        data: {
          title: 'Vis kunder',
          roles: ['Customer_View']
        }
      },
      {
        path: 'new',
        component: NewCustomerComponent,
        data: {
          title: 'Tilføj kunde',
          roles: ['Customer_Add']
        }
      },
      {
        path: 'details/:id',
        component: DetailsCustomerComponent,
        data: {
          title: 'Detaljer for kunde',
          roles: ['Customer_View']
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersRoutingModule {}
