import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Http } from '@angular/http';
import { ItemTemplate } from '../_models/ItemTemplate';
import { Observable } from 'rxjs';
import { ItemPropertyName } from '../_models/ItemPropertyName';

@Injectable()
export class ItemTemplateService {
    baseUrl = environment.apiUrl;

    constructor(private http: Http) {}

    getItemTemplates(): Observable<ItemTemplate[]> {
        return this.http.get(this.baseUrl + 'ItemTemplate/getAll')
            .map(response => <ItemTemplate[]>response.json());
    }

    getItemTemplate(id: number): Observable<ItemTemplate> {
        return this.http.get(this.baseUrl + 'ItemTemplate/get/' + id)
            .map(response => <ItemTemplate>response.json());
    }

    addTemplateProperty(property: ItemPropertyName): Observable<ItemPropertyName> {
        return this.http.post(this.baseUrl + 'ItemTemplate/addProperty', property)
        .map(response => <ItemPropertyName>response.json());
    }

    deleteItemTemplate(id) {
        return this.http.post(this.baseUrl + 'ItemTemplate/delete/' + id, {})
        .map(response => {});
    }

    getAllTemplateProperties(): Observable<ItemPropertyName[]> {
        return this.http.get(this.baseUrl + 'ItemTemplate/getPropertyNames')
            .map(response => <ItemPropertyName[]>response.json());
    }

    addTemplate(template: ItemTemplate): Observable<ItemTemplate> {
      return this.http.post(this.baseUrl + 'ItemTemplate/add', template)
      .map(response => <ItemTemplate>response.json());
    }


}
