import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewUserRolesComponent } from './new-user-roles.component';
import { UserRolesRoutingModule } from './user-roles-routing.module';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    UserRolesRoutingModule,
    [CollapseModule.forRoot()],
    FormsModule,
  ],
  declarations: [
    NewUserRolesComponent,
  ]

})
export class UserRolesModule { }
