import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import 'rxjs/add/operator/map';
import { environment } from '../../environments/environment';
import { User } from '../_models/User';
import { initDomAdapter } from '@angular/platform-browser/src/browser';
import { AlertifyService } from './alertify.service';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Injectable()
export class AuthService {
    baseUrl = environment.apiUrl + 'auth/';
    userToken: any;
    decodedToken: any;
    currentUser: User;
    jwtHelper: JwtHelperService = new JwtHelperService();
    constructor(private http: Http, private alertify: AlertifyService, private router: Router) { }

    login(model: any) {

        return this.http.post(this.baseUrl + 'login', model, this.requestOptions())
        .map((response: Response) => {
            const user = response.json();
            if (user && user.token) {
                localStorage.setItem('token', user.token);
                localStorage.setItem('user', JSON.stringify(user.user));
                this.decodedToken = this.jwtHelper.decodeToken(user.token);
                this.userToken = user.token;
            }
        });
    }

    updateToken(username: string) {

        return this.http.post(this.baseUrl + 'updateToken', username, this.requestOptions())
        .map((response: Response) => {
            const user = response.json();
            if (user && user.token) {
                localStorage.setItem('token', user.token);
                localStorage.setItem('user', JSON.stringify(user.user));
                this.decodedToken = this.jwtHelper.decodeToken(user.token);
                this.userToken = user.token;
            }
        });
    }

    register(model: any) {
        return this.http.post(this.baseUrl + 'register', model, this.requestOptions());
    }

    loggedIn() {
        const token = localStorage.getItem('token');
        return !this.jwtHelper.isTokenExpired(token);
    }

    logout() {
        this.router.navigate(['login']);
        this.userToken = null;
        localStorage.removeItem('token');
        this.alertify.success('Logget ud');
      }

    getCurrentUserId() {
        this.currentUser = JSON.parse(localStorage.getItem('user'));
        return this.currentUser.id.toString();
    }

    getCurrentUser() {
        this.currentUser = JSON.parse(localStorage.getItem('user'));
        return this.currentUser;
    }

    roleMatch(allowedRoles): boolean {
        let isMatch = false;
        const userRoles = this.decodedToken.role as Array<string>;
        if (!userRoles) {
            return false;
        }
        allowedRoles.forEach(element => {
            if (userRoles.includes(element)) {
                isMatch = true;
                return;
            }
        });
        return isMatch;
    }

    private requestOptions() {
        const headers = new Headers({'Content-type': 'application/json'});
        return new RequestOptions({headers: headers});
    }
}
