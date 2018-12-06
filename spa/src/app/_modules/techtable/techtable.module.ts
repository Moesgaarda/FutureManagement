import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TechtableComponent } from './techtable.component';
import { Ng2TableModule } from 'ng2-table/ng2-table';
import { FormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap/pagination';


@NgModule({
    imports: [
        CommonModule,
        Ng2TableModule,
        FormsModule,
        PaginationModule.forRoot()
    ],
    declarations: [
        TechtableComponent
    ],
    exports: [
        TechtableComponent
    ]
})

export class TechTableModule { }
