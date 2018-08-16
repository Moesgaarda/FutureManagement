import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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
}
