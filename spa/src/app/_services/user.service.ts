import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { User } from '../_models/User';
import { Jsonp } from '@angular/http';
import { URLSearchParams } from '@angular/http';
import { UserRole } from '../_models/UserRole';
import { RoleCategory } from '../_models/RoleCategory';


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
  activateUser(id: number) {
    return this.http.post(this.baseUrl + 'User/activate/' + id, {});
  }
  deActivateUser(id: number) {
    return this.http.post(this.baseUrl + 'User/deactivate/' + id, {});
  }
  editUser(user: User) {
    return this.http.post<User>(this.baseUrl + 'User/edit', user);
  }
  addRoleCategory(newRoleCategory: RoleCategory): Observable<RoleCategory> {
    return this.http.post<RoleCategory>(this.baseUrl + 'User/AddRoleCategory', newRoleCategory, this.httpOptions);
  }
  getAllRoleCategories(): Observable<RoleCategory[]> {
    return this.http.get<RoleCategory[]>(this.baseUrl + 'User/GetAllRoleCategories');
  }
  getAllRoles(): Observable<UserRole[]> {
    return this.http.get<UserRole[]>(this.baseUrl + 'User/GetAllRoles');
  }
}
