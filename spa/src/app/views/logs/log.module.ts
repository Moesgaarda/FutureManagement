import { NgModule } from '@angular/core';

import { ViewLogComponent } from './view-log.component';
import { FormsModule } from '@angular/forms';
import { LogRoutingModule } from './log-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  imports: [
    LogRoutingModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
  ],
  declarations: [
    ViewLogComponent,
   ]
})
export class LogModule { }
