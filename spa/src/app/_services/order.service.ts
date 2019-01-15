import { Injectable } from '@angular/core';
import { Order } from '../_models/Order';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { promise } from 'protractor';

@Injectable()
export class OrderService {

    baseUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
          'Access-Control-Allow-Origin': '*',
        }),
      };

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

    async getOrder(id: number): Promise<Order> {
        return new Promise<Order>(resolve => {
            resolve(this.http.get<Order>(this.baseUrl + 'Order/get/' + id).toPromise());
        });
    }

    deleteOrder(id: number) {
        return this.http.post(this.baseUrl + 'Order/delete/' + id, {})
        .map(response => {});
    }

    addOrder(order: Order): Observable<Order> {
        return this.http.post<Order>(this.baseUrl + 'Order/add', order);
    }

    statusUpdateOrder(order: Order): Observable<Order> {
        return this.http.post<Order>(this.baseUrl + 'Order/updateStatus', order, this.httpOptions);
    }
}
