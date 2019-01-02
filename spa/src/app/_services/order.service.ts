import { Injectable } from '@angular/core';
import { Order } from '../_models/Order';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { promise } from 'protractor';
import { OrderStatus } from '../_models/OrderStatus';

@Injectable()
export class OrderService {

    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {}

    getAll(): Observable<Order[]> {
        return this.http.get<Order[]>(this.baseUrl + 'Order/getAll');
    }

    getIncomingOrders(): Observable<Order[]> {
        return this.http.get<Order[]>(this.baseUrl + 'Order/getIncoming');
    }

    getNotDelivered(): Observable<Order[]> {
        return this.http.get<Order[]>(this.baseUrl + 'Order/getNotDelivered');
    }

    getOrder(id: number): Observable<Order> {
        return this.http.get<Order>(this.baseUrl + 'Order/get/' + id);
    }

    getAllStatuses(): Promise<OrderStatus[]> {
        return new Promise<OrderStatus[]>(resolve => {
            resolve(this.http.get<OrderStatus[]>(this.baseUrl + 'Order/getAllStatuses').toPromise());
        });
    }

    deleteOrder(id: number) {
        return this.http.post(this.baseUrl + 'Order/delete/' + id, {})
        .map(response => {});
    }

    addOrder(order: Order): Observable<Order> {
        return this.http.post<Order>(this.baseUrl + 'Order/add', order);
    }
}
