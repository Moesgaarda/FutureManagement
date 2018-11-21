import { NgModule } from '@angular/core';

import { ViewLogComponent } from './view-log.component';
import { FormsModule } from '@angular/forms';
import { LogRoutingModule } from './log-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { Ng2TableModule } from 'ng2-table';
import { TechtableComponent } from '../../_components/techtable/techtable.component';

@NgModule({
  imports: [
    LogRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule
  ],
  declarations: [
    ViewLogComponent,
    TechtableComponent
   ]
})
export class LogModule { }
