import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewUserRolesComponent } from './new-user-roles.component';
import { AuthGuard } from '../../_guards/auth.guard';

const routes: Routes = [
    {
    path: '',
    data: {
      title: 'Roller'
    },
    canActivate: [AuthGuard],
    children: [
        {
            path: 'new',
            component: NewUserRolesComponent,
            data: {
              title: 'Ny rolle',
              roles: ['User_Add']
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
