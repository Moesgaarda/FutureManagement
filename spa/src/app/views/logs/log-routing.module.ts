import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewLogComponent } from './view-log.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Data log'
    },
    children: [
      {
        path: 'view',
        component: ViewLogComponent,
        data: {
          title: 'Vis data log'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LogRoutingModule {}
