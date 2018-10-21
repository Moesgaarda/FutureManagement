import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ItemTemplate } from '../_models/ItemTemplate';
import { Observable } from 'rxjs';
import { ItemPropertyName } from '../_models/ItemPropertyName';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { DetailFile } from '../_models/DetailFile';

@Injectable()
export class ItemTemplateService {
    baseUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
        }),
      };

    constructor(private http: HttpClient) {}

    getItemTemplates(): Observable<ItemTemplate[]> {
        return this.http.get<ItemTemplate[]>(this.baseUrl + 'ItemTemplate/getAll');
    }

    getItemTemplate(id: number): Observable<ItemTemplate> {
        return this.http.get<ItemTemplate>(this.baseUrl + 'ItemTemplate/get/' + id);
    }

    deleteItemTemplate(id: number) {
        return this.http.post(this.baseUrl + 'ItemTemplate/delete/' + id, {})
        .map(response => {});
    }

    getAllTemplateProperties(): Observable<ItemPropertyName[]> {
        return this.http.get<ItemPropertyName[]>(this.baseUrl + 'ItemTemplate/getPropertyNames');
    }

    addTemplate(template: ItemTemplate): Observable<ItemTemplate> {
        return this.http.post<ItemTemplate>(this.baseUrl + 'ItemTemplate/add', template, this.httpOptions);
    }

    addTemplateProperty(property: ItemPropertyName): Observable<ItemPropertyName> {
        return this.http.post<ItemPropertyName>(this.baseUrl + 'ItemTemplate/addProperty', property, this.httpOptions);
    }

    getFiles(id: number): Observable<DetailFile[]> {
        return this.http.get<DetailFile[]>(this.baseUrl + 'ItemTemplate/getFiles/' + id);
    }


}
