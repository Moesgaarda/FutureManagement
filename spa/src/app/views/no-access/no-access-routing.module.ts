import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NoAccessComponent } from './no-access.component';

const routes: Routes = [
  {
    path: '',
    children: [
        {
          path: '',
          component: NoAccessComponent,
          data: {
            title: 'Ingen Adgang'
          }
        },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NoAccessRoutingModule {}
