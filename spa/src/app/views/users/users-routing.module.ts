import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewUsersComponent } from './view-users.component';
import { NewUserComponent } from './new-user.component';
import { EditUserComponent } from './edit-user.component';
import { DetailsUserComponent } from './details-user.component';



const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Brugere'
    },
    children: [
      {
        path: 'view',
        component: ViewUsersComponent,
        data: {
          title: 'Vis brugere'
        }
      },
      {
        path: 'new',
        component: NewUserComponent,
        data: {
          title: 'Tilføj ny bruger'
        }
      },
      {
        path: 'edit',
        component: EditUserComponent,
        data: {
            title: 'Rediger bruger'
        }
      },
      {
        path: 'details',
        component: DetailsUserComponent,
        data: {
          title: 'Detaljer om bruger'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule {}
