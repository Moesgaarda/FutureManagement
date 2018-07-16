import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { NewComponent } from './new.component';
import { routing } from './new.routing';
import { RegisterComponent } from '../register/register.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    routing,
  ],
  declarations: [
    NewComponent,
    RegisterComponent,
  ],
})
export class NewModule {}
