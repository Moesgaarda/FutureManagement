import { Injectable } from '@angular/core';
import { Order } from '../_models/Order';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class OrderService {

    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {}

    getAllOrders(): Observable<Order[]> {
        return this.http.get<Order[]>(this.baseUrl + 'Order/getAll');
    }

    getOrder(id: number): Observable<Order> {
        return this.http.get<Order>(this.baseUrl + 'Order/get/' + id);
    }

    deleteOrder(id: number) {
        return this.http.post(this.baseUrl + 'Order/delete/' + id, {})
        .map(response => {});
    }

    addOrder(order: Order): Observable<Order> {
        return this.http.post<Order>(this.baseUrl + 'Order/add', order);
    }
}
