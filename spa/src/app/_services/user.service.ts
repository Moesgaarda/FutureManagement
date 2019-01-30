import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { User } from '../_models/User';
import { Jsonp } from '@angular/http';
import { URLSearchParams } from '@angular/http';
import { UserRole } from '../_models/UserRole';
import { RoleName } from '../_models/RoleName';


@Injectable()
export class UserService {
  baseUrl = environment.apiUrl;

  httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      }),
    };

  constructor(private http: HttpClient) {}

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'User/active');
  }
  getInactiveUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'User/inactive');
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'User/get/' + id);
  }

  getMyUser(id: number): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'User/get/my');
  }

  deleteUser(id: number) {
    return this.http.post(this.baseUrl + 'User/delete/' + id, {})
    .map(response => {});
  }
  deActivateUser(id: number) {
    return this.http.post(this.baseUrl + 'User/deactivate/' + id, {});
  }
  editUser(user: User) {
    return this.http.post<User>(this.baseUrl + 'User/edit', user);
  }
  addUserRole(newRole: RoleName) {
    return this.http.post<RoleName>(this.baseUrl + 'User/addRole' + newRole, {});
  }
  getAllRoles(): Observable<RoleName[]> {
    return this.http.get<RoleName[]>(this.baseUrl + 'User/GetAllRoles');
  }
}
