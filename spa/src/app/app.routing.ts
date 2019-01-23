import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Import Containers
import { DefaultLayoutComponent } from './containers';
import { LoginComponent } from './views/login/login.component';
import { AuthGuard } from './_guards/auth.guard';


export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
    canActivate: [AuthGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Login Page'
    }
  },
  {
    path: '',
    component: DefaultLayoutComponent,
    canActivate: [AuthGuard],
    data: {
      title: 'Home',
    },
    children: [
      {
        path: 'projects',
        loadChildren: './views/projects/projects.module#ProjectsModule'
      },
      {
        path: 'customers',
        loadChildren: './views/customers/customers.module#CustomersModule'
      },
      {
        path: 'items',
        loadChildren: './views/items/items.module#ItemsModule'
      },
      {
        path: 'itemTemplates',
        loadChildren: './views/itemTemplates/itemTemplates.module#ItemTemplatesModule'
      },
      {
        path: 'orders',
        loadChildren: './views/orders/orders.module#OrdersModule'
      },
      {
        path: 'userRoles',
        loadChildren: './views/user-roles/user-roles.module#UserRolesModule'
      },
      {
        path: 'users',
        loadChildren: './views/users/users.module#UsersModule'
      },
      {
        path: 'no-access',
        loadChildren: './views/no-access/no-access.module#NoAccessModule'
      },
      {
        path: 'dashboard',
        loadChildren: './views/dashboard/dashboard.module#DashboardModule'
      },
      {
        path: 'logs',
        loadChildren: './views/logs/log.module#LogModule'
      },
      {
        path: 'unitTypes',
        loadChildren: './views/unitTypes/unitTypes.module#UnitTypeModule'
      },
      {
        path: 'categories',
        loadChildren: './views/categories/categories.module#CategoryModule'
      }
    ]
  }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
