import { Component, Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpRequest, HttpClient, HttpEventType } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Response } from '@angular/http'

@Component({
  selector: 'ngx-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css'],
})
@Injectable()
export class FileUploadComponent {
  baseUrl = environment.apiUrl;
  public progress: number;
  public message: string;
  public queuedFiles: any [] = [];
  fileIds: number[];
  constructor(private http: HttpClient) { }

  queue(files: any []) {
    for (const file of files){
      this.queuedFiles.push(file);
    }
  }
  clearQueue() {
    this.queuedFiles.splice(0, this.queuedFiles.length);
  }
  async upload(): Promise<number []> {
    try {
      if (this.queuedFiles.length === 0) {
        return;
      }
      const formData = new FormData();
      for (const file of this.queuedFiles){
        formData.append(file.name, file);
      }
      const uploadReq = new HttpRequest('POST', this.baseUrl + 'FileInput/uploadfiles', formData, {
        reportProgress: true,
      });
      const result = await this.http.post(this.baseUrl + 'FileInput/uploadfiles', formData).toPromise();
      return result as number [];
    } catch (error) {
      console.log(error);
    }
  }
}