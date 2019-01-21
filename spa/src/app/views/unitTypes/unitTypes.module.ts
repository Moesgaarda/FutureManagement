import { NgModule } from '@angular/core';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxPaginationModule } from 'ngx-pagination';
import { UnitTypesRoutingModule } from './unitTypes-routing.module';
import { Ng2TableModule } from 'ng2-table/ng2-table';

import { DetailsUnitTypeComponent } from './details-unitType.component';
import { ViewUnitTypesComponent } from './view-unitTypes.component';
import { NewUnitTypeComponent } from './new-unitType.component';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { TechTableModule} from '../../_modules/techtable/techtable.module';
import { PropertyFilterPipe } from '../../_pipes/property-filter.pipe';

@NgModule({
  imports: [
    UnitTypesRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    CommonModule,
    NgSelectModule,
    Ng2TableModule,
    TechTableModule,
    NgxPaginationModule,
  ],
  declarations: [
    ViewUnitTypesComponent,
    NewUnitTypeComponent,
    DetailsUnitTypeComponent,
    PropertyFilterPipe
  ]
})
export class UnitTypeModule { }
