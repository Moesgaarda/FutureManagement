import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewLogComponent } from './view-log.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Data log'
    },
    canActivateChild: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'view'
      },
      {
        path: 'view',
        component: ViewLogComponent,
        data: {
          title: 'Vis data log',
          roles: ['EventLogs_View']
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
