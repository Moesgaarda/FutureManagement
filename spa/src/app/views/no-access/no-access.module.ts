import { NgModule } from '@angular/core';
import { NoAccessComponent } from './no-access.component';
import { NoAccessRoutingModule } from './no-access-routing.module';

@NgModule({
  imports: [
    NoAccessRoutingModule,
  ],
  declarations: [
      NoAccessComponent,
   ]
})
export class NoAccessModule { }
