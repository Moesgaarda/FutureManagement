import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TechkrustableComponent } from './techkrustable.component';
import { Ng2TableModule } from 'ng2-table';
import { NgSelectModule } from '@ng-select/ng-select';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule } from '@angular/forms';
import { TechtableComponent } from '../techtable/techtable.component';

@NgModule({
  imports: [
    CommonModule,
    Ng2TableModule,
    NgSelectModule,
    PaginationModule.forRoot(),
    FormsModule,
    TechtableComponent
  ],
  declarations: [TechkrustableComponent, TechtableComponent]
})
export class TechkrustableModule { }
