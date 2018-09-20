import { NgModule } from '@angular/core';

import { ThemeModule } from '../../@theme/theme.module';
import { FormsRoutingModule, routedComponents } from './forms-routing.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { FileUploadModule } from 'ng2-file-upload';
import { FileUploader } from 'ng2-file-upload';

@NgModule({
  imports: [
    ThemeModule,
    FormsRoutingModule,
    NgSelectModule,
    FileUploadModule,
  ],
  declarations: [
    ...routedComponents,
  ],
})
export class FormsModule { }
