import { NgModule } from '@angular/core';

import { ThemeModule } from '../../@theme/theme.module';
import { FormsRoutingModule, routedComponents } from './forms-routing.module';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  imports: [
    ThemeModule,
    FormsRoutingModule,
    NgSelectModule,
  ],
  declarations: [
    ...routedComponents,
  ],
})
export class FormsModule { }
