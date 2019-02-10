import { NgModule } from '@angular/core';

import { ViewLogComponent } from './view-log.component';
import { FormsModule } from '@angular/forms';
import { LogRoutingModule } from './log-routing.module';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { TechTableModule } from '../../_modules/techtable/techtable.module';

@NgModule({
  imports: [
    LogRoutingModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
    TechTableModule,
  ],
  declarations: [
    ViewLogComponent,
   ]
})
export class LogModule { }
