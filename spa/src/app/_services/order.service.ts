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
}
