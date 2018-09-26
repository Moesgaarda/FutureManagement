import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewCustomersComponent } from './view-customers.component';
import { NewCustomerComponent } from './new-customer.component';
import { DetailsCustomerComponent } from './details-customer.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Kunder'
    },
    children: [
      {
        path: 'view',
        component: ViewCustomersComponent,
        data: {
          title: 'Vis kunder'
        }
      },
      {
        path: 'new',
        component: NewCustomerComponent,
        data: {
          title: 'Tilføj kunde'
        }
      },
      {
        path: 'details/:id',
        component: DetailsCustomerComponent,
        data: {
          title: 'Detaljer for kunde'
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
