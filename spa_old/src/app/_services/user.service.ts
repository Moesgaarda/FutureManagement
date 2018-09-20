import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { User } from '../_models/User';


@Injectable()
export class UserService {
  baseUrl = environment.apiUrl;

  httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      }),
    };

  constructor(private http: HttpClient) {}

  getActiveUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'User/active');
  }
  getInactiveUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'User/inactive');
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'User/get/' + id);
  }

  deleteUser(id: number) {
    return this.http.post(this.baseUrl + 'User/delete/' + id, {})
    .map(response => {});
  }
  deActivateUser(id: number) {
    return this.http.post(this.baseUrl + 'User/deactivate/' + id, {});
  }
}
