import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient, HttpParams, HttpRequest} from '@angular/common/http';
import {saveAs} from 'file-saver';
import {DetailFile} from '../_models/DetailFile';

@Injectable()
export class FileUploadService {
  baseUrl = environment.apiUrl;
  public progress: number;
  public message: string;
  public queuedFiles: File [] = [];
  fileIds: number[];

  constructor(private http: HttpClient) {
  }

  /**
   *Adds files to the Upload queue
   *
   * @param {File []} files files that are to be added
   * @memberof FileUploadService
   */
  queue(files: File []) {
    for (const file of files) {
      this.queuedFiles.push(file);
    }
  }

  /**
   *Empties the upload queue
   *
   * @memberof FileUploadService
   */
  clearQueue() {
    this.queuedFiles.splice(0, this.queuedFiles.length);
  }

  /**
   *Remove a file from the upload queue
   *
   * @param {File} file file to be removed
   * @memberof FileUploadService
   */
  removeFromQueue(file: File) {
    this.queuedFiles.splice(this.queuedFiles.indexOf(file), 1);
  }

  /**
   *Sends a post request to the controller with the files that are to be uploaded
   *
   * @param {string} origin which of the components the request is made from. This is used to save the files in the correct path in the API
   * @returns {Promise<number []>} Returns the FileData Id of the uploaded files.
   * @memberof FileUploadService
   */
  async upload(origin: string): Promise<number []> {
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
  }

  async download(fileDetails: DetailFile, origin: string) {
    const headers = new Headers();
    headers.append('content-type', 'application/json');
    const id = fileDetails.fileDataId.toString();
    const params = new HttpParams().set('id', id).set('origin', origin);
    this.http.get(this.baseUrl + 'FileInput/downloadfile', {responseType: 'blob', params: params}).subscribe(blob => {
      saveAs(blob, fileDetails.fileName, {
        type: 'text/plain;charset=utf-8'
      });
    });
  }
}
