import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotFoundComponent } from './miscellaneous/not-found/not-found.component';
import { AuthGuard } from '../_guards/auth.guard';

const routes: Routes = [{
  path: '',
  component: PagesComponent,
  children: [{
    path: 'dashboard',
    component: DashboardComponent,
    // canActivate: [AuthGuard],
  }, {
    path: 'ui-features',
    loadChildren: './ui-features/ui-features.module#UiFeaturesModule', // canActivate: [AuthGuard],
  }, {
    path: 'components',
    loadChildren: './components/components.module#ComponentsModule', // canActivate: [AuthGuard],
  }, {
    path: 'maps',
    loadChildren: './maps/maps.module#MapsModule', //  canActivate: [AuthGuard],
  }, {
    path: 'charts',
    loadChildren: './charts/charts.module#ChartsModule',  // canActivate: [AuthGuard],
  }, {
    path: 'editors',
    loadChildren: './editors/editors.module#EditorsModule',  // canActivate: [AuthGuard],
  }, {
    path: 'forms',
    loadChildren: './forms/forms.module#FormsModule', // canActivate: [AuthGuard],
  }, {
    path: 'tables',
    loadChildren: './tables/tables.module#TablesModule', // canActivate: [AuthGuard],
  }, {
    path: 'miscellaneous',
    loadChildren: './miscellaneous/miscellaneous.module#MiscellaneousModule', // canActivate: [AuthGuard],
  },  {
    path: 'new',  loadChildren: './new/new.module#NewModule',
  },
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  }, {
    path: '**',
    component: NotFoundComponent,
  }],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
