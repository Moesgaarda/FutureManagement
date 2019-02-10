import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Item } from '../_models/Item';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ItemTemplate } from '../_models/ItemTemplate';


@Injectable()
export class ItemService {

    baseUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
          'Access-Control-Allow-Origin': '*',
        }),
      };

    constructor(private http: HttpClient) {}

    getAll(): Observable<Item[]> {
        return this.http.get<Item[]>(this.baseUrl + 'Item/getAll');
    }

    getActiveItems(): Observable<Item[]> {
        return this.http.get<Item[]>(this.baseUrl + 'Item/getActive');
    }

    getLowInventory(): Observable<Item[]> {
        return this.http.get<Item[]>(this.baseUrl + 'Item/getLowInventory');
    }

    getInactiveItems(): Observable<Item[]> {
        return this.http.get<Item[]>(this.baseUrl + 'Item/getInactive');
    }

    getItem(id: number): Observable<Item> {
        return this.http.get<Item>(this.baseUrl + 'Item/get/' + id);
    }

    deleteItem(id: number) {
        return this.http.post(this.baseUrl + 'Item/delete/' + id, {})
        .map(response => {});
    }

    addItem(item: Item): Observable<Item> {
        return this.http.post<Item>(this.baseUrl + 'Item/add', item, this.httpOptions);
    }

    editItem(item: Item): Observable<Item> {
        return this.http.post<Item>(this.baseUrl + 'Item/edit', item, this.httpOptions);
    }

    getAllInstancesInStock(template: ItemTemplate): Observable<Item[]> {
        return this.http.get<Item[]>(this.baseUrl + 'Item/getAllInstancesInStock/' + template.id);
    }
}
