import { NgModule } from '@angular/core';

import { Ng2TableModule } from 'ng2-table/ng2-table';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ViewUsersComponent } from './view-users.component';
import { NewUserComponent } from './new-user.component';
import { EditUserComponent } from './edit-user.component';
import { DetailsUserComponent } from './details-user.component';
import { FormsModule } from '@angular/forms';
import { UsersRoutingModule } from './users-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { TechTableModule } from '../../_modules/techtable/techtable.module';
import { UserRoleFilterPipe } from '../../_pipes/role-filter.pipe';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { ViewDeactivatedUsersComponent } from './view-deactivated-users.component';

@NgModule({
  imports: [
    UsersRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule,
    TechTableModule,
    NgxPaginationModule,
    Ng4LoadingSpinnerModule
  ],
  declarations: [
    ViewUsersComponent,
    NewUserComponent,
    EditUserComponent,
    DetailsUserComponent,
    ViewDeactivatedUsersComponent,
    UserRoleFilterPipe,

  ]
})
export class UsersModule {}
