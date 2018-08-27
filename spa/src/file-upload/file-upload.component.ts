import { Component } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { environment } from '../environments/environment';

@Component({
  selector: 'ngx-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css'],
})

export class FileUploadComponent {
  public progress: number;
  public message: string;
  public url: string;
  public queuedFiles: any;
  constructor(private http: HttpClient) { }

  queue(files) {
    this.queuedFiles.push(files);
  }
  clearQueue() {
    this.queuedFiles.splice(0, this.queuedFiles.length);
  }
  upload() {
    if (this.queuedFiles.length === 0) {
      return;
    }

    const formData = new FormData();

    for (const file of this.queuedFiles){
      formData.append(file.Name, file);
    }

    const uploadReq = new HttpRequest('POST', environment.apiUrl + '/FileInput/UploadFiles', formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      } else if ( event.type === HttpEventType.Response) {
        this.message = event.body.toString();
      }
    });
  }
}
