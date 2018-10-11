import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpRequest, HttpClient } from '@angular/common/http';
import { ResponseType } from '@angular/http';
import { saveAs } from 'file-saver';

@Injectable()
export class FileUploadService {
  baseUrl = environment.apiUrl;
  public progress: number;
  public message: string;
  public queuedFiles: File [] = [];
  fileIds: number[];
  constructor(private http: HttpClient) { }

  queue(files: File []) {
    for (const file of files) {
      this.queuedFiles.push(file);
    }
  }
  clearQueue() {
    this.queuedFiles.splice(0, this.queuedFiles.length);
  }
  removeFromQueue(file: File) {
    this.queuedFiles.splice(this.queuedFiles.indexOf(file), 1);
  }
  async upload(origin: string): Promise<number []> {
    try {
      if (this.queuedFiles.length === 0) {
        return;
      }
      const formData = new FormData();
      formData.append('origin', origin);
      for (const file of this.queuedFiles) {
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
  async download(id: number, origin: string) {}
}
