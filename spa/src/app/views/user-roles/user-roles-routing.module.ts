import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewUserRolesComponent } from './new-user-roles.component';
import { AuthGuard } from '../../_guards/auth.guard';
import { ViewUserRolesComponent } from './view-user-roles.component';

const routes: Routes = [
    {
    path: '',
    data: {
      title: 'Roller'
    },
    canActivateChild: [AuthGuard],
    children: [
        {
            path: 'new',
            component: NewUserRolesComponent,
            data: {
              title: 'Ny rolle',
              roles: ['User_Add']
            }
        },
        {
          path: 'view',
          component: ViewUserRolesComponent,
          data: {
            title: 'Vis all roller',
            roles: ['User_View']
          }
        },
    ]
    }
];


@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class UserRolesRoutingModule {}
