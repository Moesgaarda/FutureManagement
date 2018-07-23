import { NgModule } from '@angular/core';

import { ThemeModule } from '../../@theme/theme.module';
import { FormsRoutingModule, routedComponents } from './forms-routing.module';
import { SelectDropDownModule } from 'ngx-select-dropdown'

@NgModule({
  imports: [
    ThemeModule,
    FormsRoutingModule,
    SelectDropDownModule,
  ],
  declarations: [
    ...routedComponents,
  ],
})
export class FormsModule { }
