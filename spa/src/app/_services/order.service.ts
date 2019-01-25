import { Injectable } from '@angular/core';
import { Order } from '../_models/Order';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { promise } from 'protractor';
import { OrderStatusEnum } from '../_enums/OrderStatusEnum.enum';

@Injectable()
export class OrderService {

    baseUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
        }),
    };

    constructor(private http: HttpClient) { }

    getAll(): Observable<Order[]> {
        return this.http.get<Order[]>(this.baseUrl + 'Order/getAll');
    }

    getIncomingOrders(): Observable<Order[]> {
        return this.http.get<Order[]>(this.baseUrl + 'Order/getIncoming');
    }

    getNotDelivered(): Observable<Order[]> {
        return this.http.get<Order[]>(this.baseUrl + 'Order/getNotDelivered');
    }

    async getOrder(id: number): Promise<Order> {
        return new Promise<Order>(resolve => {
            resolve(this.http.get<Order>(this.baseUrl + 'Order/get/' + id).toPromise());
        });
    }

    addOrder(order: Order): Observable<Order> {
        return this.http.post<Order>(this.baseUrl + 'Order/add', order);
    }

    editOrder(order: Order): Observable<Order> {
        return this.http.post<Order>(this.baseUrl + 'Order/edit', order, this.httpOptions);
    }
}
