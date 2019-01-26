import { Injectable } from '@angular/core';
import { Order } from '../_models/Order';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { promise } from 'protractor';
import { ItemPropertyName } from '../_models/ItemPropertyName';
import { Item } from '../_models/Item';

@Injectable()
export class TemplatePropertyService {

    baseUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type':  'application/json',
            'Access-Control-Allow-Origin': '*',
        }),
    };

    constructor(private http: HttpClient) {}


    getAll(): Observable<ItemPropertyName[]> {
        return this.http.get<ItemPropertyName[]>(this.baseUrl + 'TemplateProperty/getAll');
    }

    getTemplateProperty(id: number): Observable<ItemPropertyName> {
        return this.http.get<ItemPropertyName>(this.baseUrl + 'TemplateProperty/get/' + id);
    }

    addTemplateProperty(itemPropertyName: ItemPropertyName): Observable<ItemPropertyName> {
        return this.http.post<ItemPropertyName>(this.baseUrl + 'TemplateProperty/add', itemPropertyName, this.httpOptions);
    }

    editTemplateProperty(itemPropertyName: ItemPropertyName): Observable<ItemPropertyName> {
        return this.http.post<ItemPropertyName>(this.baseUrl + 'TemplateProperty/edit', itemPropertyName, this.httpOptions);
    }

}
