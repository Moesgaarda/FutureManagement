import { NgModule } from '@angular/core';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { TemplatePropertiesRoutingModule } from './templateProperties-routing.module';
import { Ng2TableModule } from 'ng2-table/ng2-table';

import { EditTemplatePropertyComponent } from './edit-templateProperty.component';
import { ViewTemplatePropertiesComponent } from './view-templateProperties.component';
import { NewTemplatePropertyComponent } from './new-templateProperty.component';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { TechTableModule} from '../../_modules/techtable/techtable.module';

@NgModule({
  imports: [
    TemplatePropertiesRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule,
    TechTableModule,
    NgxPaginationModule,
  ],
  declarations: [
    ViewTemplatePropertiesComponent,
    NewTemplatePropertyComponent,
    EditTemplatePropertyComponent
  ]
})
export class TemplatePropertyModule { }
