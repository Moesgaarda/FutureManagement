import { Injectable } from '@angular/core';
import { Order } from '../_models/Order';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { promise } from 'protractor';
import { Category } from '../_models/Category';
import { Item } from '../_models/Item';

@Injectable()
export class CategoryService {

    baseUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type':  'application/json',
            'Access-Control-Allow-Origin': '*',
        }),
    };

    constructor(private http: HttpClient) {}


    getAll(): Observable<Category[]> {
        return this.http.get<Category[]>(this.baseUrl + 'Category/getAll');
    }

    getCategory(id: number): Observable<Category> {
        return this.http.get<Category>(this.baseUrl + 'Category/get/' + id);
    }

    addCategory(unitType: Category): Observable<Category> {
        return this.http.post<Category>(this.baseUrl + 'Category/add', unitType, this.httpOptions);
    }

    editCategory(unitType: Category): Observable<Category> {
        return this.http.post<Category>(this.baseUrl + 'Category/edit', unitType, this.httpOptions);
    }

}
