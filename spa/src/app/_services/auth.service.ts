import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import 'rxjs/add/operator/map';
import { environment } from '../../environments/environment';
import { User } from '../_models/User';

@Injectable()
export class AuthService {
    baseUrl = environment.apiUrl + 'auth/';
    userToken: any;
    decodedToken: any;
    jwtHelper: JwtHelperService = new JwtHelperService();
    constructor(private http: Http) { }
    test: any;

    login(model: any) {

        return this.http.post(this.baseUrl + 'login', model, this.requestOptions())
        .map((response: Response) => {
            const user = response.json();
            if (user && user.token) {
                localStorage.setItem('token', user.token);
                this.decodedToken = this.jwtHelper.decodeToken(user.token);
                this.userToken = user.token;
                this.test = user.user;
            }
        });
    }

    register(model: any) {
        return this.http.post(this.baseUrl + 'register', model, this.requestOptions());
    }

    loggedIn() {
        return !this.jwtHelper.isTokenExpired('token');
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
