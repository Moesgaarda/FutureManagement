import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {Customer} from '../_models/Customer';
import {Observable} from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';


@Injectable()
export class CustomerService {

  baseUrl = environment.apiUrl;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
    }),
  };

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl + 'Customer/getAll');
  }

  getActiveCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl + 'Customer/getActive');
  }

  getInactiveCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl + 'Customer/getInactive');
  }

  getCustomer(id: number): Observable<Customer> {
    return this.http.get<Customer>(this.baseUrl + 'Customer/get/' + id);
  }

  deleteCustomer(id: number) {
    return this.http.post(this.baseUrl + 'Customer/delete/' + id, {})
      .map(response => {
      });
  }

  addCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.baseUrl + 'Customer/add', customer, this.httpOptions);
  }
}
