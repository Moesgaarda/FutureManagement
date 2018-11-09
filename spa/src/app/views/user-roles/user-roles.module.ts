import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewUserRolesComponent } from './new-user-roles.component';
import { UserRolesRoutingModule } from './user-roles-routing.module';
import { CollapseModule } from 'ngx-bootstrap/collapse';


@NgModule({
  imports: [
    CommonModule,
    UserRolesRoutingModule,
    [CollapseModule.forRoot()],
  ],
  declarations: [
    NewUserRolesComponent,
  ]

})
export class UserRolesModule { }
