import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Item } from '../_models/Item';
import { Observable } from 'rxjs';
import { Http } from '@angular/http';


@Injectable()
export class ItemService {

    baseUrl = environment.apiUrl;

    constructor(private http: Http) {}

    getAllItems(): Observable<Item[]> {
        return this.http.get(this.baseUrl + 'Item/getAll')
            .map(response => <Item[]>response.json());
    }

    getActiveItems(): Observable<Item[]> {
        return this.http.get(this.baseUrl + 'Item/getActive')
            .map(response => <Item[]>response.json());
    }

    getInactiveItems(): Observable<Item[]> {
        return this.http.get(this.baseUrl + 'Item/getInactive')
            .map(response => <Item[]>response.json());
    }

    getItem(id: number): Observable<Item> {
        return this.http.get(this.baseUrl + 'Item/get/' + id)
            .map(response => <Item>response.json());
    }

    deleteItem(id) {
        return this.http.post(this.baseUrl + 'Item/delete/' + id, {})
        .map(response => {});
    }

}
