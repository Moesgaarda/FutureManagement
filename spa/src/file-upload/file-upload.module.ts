import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadComponent } from './file-upload.component';
import { HttpClient} from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [FileUploadComponent],
  exports: [FileUploadComponent],
  providers: [HttpClient],
})
export class FileUploadModule { }
