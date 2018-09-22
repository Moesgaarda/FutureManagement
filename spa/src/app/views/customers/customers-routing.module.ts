import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewCustomersComponent } from './view-customers.component';

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
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomersRoutingModule {}
