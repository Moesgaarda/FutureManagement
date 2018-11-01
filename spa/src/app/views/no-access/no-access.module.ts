import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NoAccessComponent } from './no-access.component';
import { NoAccessRoutingModule } from './no-access-routing.module';

@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    NoAccessRoutingModule,
  ],
  declarations: [
      NoAccessComponent,
   ]
})
export class NoAccessModule { }
