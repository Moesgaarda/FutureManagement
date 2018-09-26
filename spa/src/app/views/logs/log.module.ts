import { NgModule } from '@angular/core';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ViewLogComponent } from './view-log.component';
import { FormsModule } from '@angular/forms';
import { LogRoutingModule } from './log-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  imports: [
    LogRoutingModule,
    Ng2SmartTableModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
  ],
  declarations: [
    ViewLogComponent
   ]
})
export class LogModule { }
