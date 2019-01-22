import { NgModule } from '@angular/core';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { CategoriesRoutingModule } from './categories-routing.module';
import { Ng2TableModule } from 'ng2-table/ng2-table';

import { EditCategoryComponent } from './edit-category.component';
import { ViewCategoriesComponent } from './view-categories.component';
import { NewCategoryComponent } from './new-category.component';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { TechTableModule} from '../../_modules/techtable/techtable.module';

@NgModule({
  imports: [
    CategoriesRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule,
    TechTableModule,
    NgxPaginationModule,
  ],
  declarations: [
    ViewCategoriesComponent,
    NewCategoryComponent,
    EditCategoryComponent
  ]
})
export class CategoryModule { }
