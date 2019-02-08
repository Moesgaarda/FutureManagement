import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {ItemTemplate} from '../_models/ItemTemplate';
import {Observable} from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable()
export class ItemTemplateService {
  baseUrl = environment.apiUrl;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<ItemTemplate[]> {
    return this.http.get<ItemTemplate[]>(this.baseUrl + 'ItemTemplate/getAll');
  }

  getItemTemplate(id: number): Observable<ItemTemplate> {
    return this.http.get<ItemTemplate>(this.baseUrl + 'ItemTemplate/get/' + id);
  }

  async getItemTemplateAsync(id: number): Promise<ItemTemplate> {
    return new Promise<ItemTemplate>(resolve => {
      resolve(this.http.get<ItemTemplate>(this.baseUrl + 'ItemTemplate/get/' + id).toPromise());
    });
  }

  deleteItemTemplate(id: number) {
    return this.http.post(this.baseUrl + 'ItemTemplate/delete/' + id, {})
      .map(response => {
      });
  }

  addTemplate(template: ItemTemplate): Observable<ItemTemplate> {
    return this.http.post<ItemTemplate>(this.baseUrl + 'ItemTemplate/add', template, this.httpOptions);
  }

}
