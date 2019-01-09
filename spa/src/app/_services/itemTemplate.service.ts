import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ItemTemplate } from '../_models/ItemTemplate';
import { Observable } from 'rxjs';
import { ItemPropertyName } from '../_models/ItemPropertyName';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { DetailFile } from '../_models/DetailFile';
import { ItemTemplateCategory } from '../_models/ItemTemplateCategory';
import { UnitType } from '../_models/UnitType';

@Injectable()
export class ItemTemplateService {
    baseUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
        }),
      };

    constructor(private http: HttpClient) {}

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
        .map(response => {});
    }

    getTemplateProperties(): Observable<ItemPropertyName[]> {
        return this.http.get<ItemPropertyName[]>(this.baseUrl + 'ItemTemplate/getPropertyNames');
    }

    addTemplate(template: ItemTemplate): Observable<ItemTemplate> {
        return this.http.post<ItemTemplate>(this.baseUrl + 'ItemTemplate/add', template, this.httpOptions);
    }

    addTemplateProperty(property: ItemPropertyName): Observable<ItemPropertyName> {
        return this.http.post<ItemPropertyName>(this.baseUrl + 'ItemTemplate/addProperty', property, this.httpOptions);
    }

    addTemplateCategory(category: ItemTemplateCategory): Observable<ItemTemplateCategory> {
        return this.http.post<ItemTemplateCategory>(this.baseUrl + 'ItemTemplate/addCategory', category, this.httpOptions);
    }

    getTemplateCategories(): Observable<ItemTemplateCategory[]> {
        return this.http.get<ItemTemplateCategory[]>(this.baseUrl + 'ItemTemplate/getTemplateCategories');
    }

    getUnitTypes(): Observable<UnitType[]> {
        return this.http.get<UnitType[]>(this.baseUrl + 'ItemTemplate/getUnitTypes');
    }

    addUnitType(unitType: UnitType): Observable<UnitType> {
        return this.http.post<UnitType>(this.baseUrl + 'ItemTemplate/addUnitType', unitType, this.httpOptions);
    }


}
