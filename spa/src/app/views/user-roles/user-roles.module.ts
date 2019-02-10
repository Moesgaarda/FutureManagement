import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewUserRolesComponent } from './new-user-roles.component';
import { UserRolesRoutingModule } from './user-roles-routing.module';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { FormsModule } from '@angular/forms';
import { ViewUserRolesComponent } from './view-user-roles.component';
import { TechTableModule } from '../../_modules/techtable/techtable.module';


@NgModule({
  imports: [
    CommonModule,
    UserRolesRoutingModule,
    TechTableModule,
    [CollapseModule.forRoot()],
    FormsModule,
  ],
  declarations: [
    NewUserRolesComponent,
    ViewUserRolesComponent,
  ]

})
export class UserRolesModule { }
