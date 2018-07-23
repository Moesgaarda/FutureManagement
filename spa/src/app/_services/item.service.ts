import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Item } from '../_models/Item';
import { Observable } from '../../../node_modules/rxjs';
import { Http } from '../../../node_modules/@angular/http';


@Injectable()
export class ItemService {

    baseUrl = environment.apiUrl;

    constructor(private http: Http) {}

    getItems(): Observable<Item[]> {
        return this.http.get(this.baseUrl + 'Item/getItems')
            .map(response => <Item[]>response.json());
    }

    getItem(id: number): Observable<Item> {
        return this.http.get(this.baseUrl + 'Item/getItem/' + id)
            .map(response => <Item>response.json());
    }

    deleteItem(id) {
        return this.http.post(this.baseUrl + 'Item/delete/' + id, {})
        .map(response => {});
    }

}
