import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewUserRolesComponent } from './new-user-roles.component';

const routes: Routes = [
    {
    path: '',
    data: {
      title: 'Roller'
    },
    children: [
        {
            path: 'new',
            component: NewUserRolesComponent,
            data: {
              title: 'Ny rolle'
            }
        },
    ]
    }
];


@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class UsersRolesRoutingModule {}
