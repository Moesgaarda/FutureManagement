import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {NoAccessComponent} from './no-access.component';
import {AuthGuard} from '../../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
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
export class NoAccessRoutingModule {
}
