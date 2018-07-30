import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { tokenNotExpired, JwtHelper } from 'angular2-jwt';
import 'rxjs/add/operator/map';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthService {
    baseUrl = environment.apiUrl + '/api/auth/';
    userToken: any;
    decodedToken: any;
    jwtHelper: JwtHelper = new JwtHelper();

    constructor(private http: Http) { }

    login(model: any) {

        return this.http.post(this.baseUrl + 'login', model, this.requestOptions())
        .map((response: Response) => {
            const user = response.json();
            if (user && user.tokenString) {
                localStorage.setItem('token', user.tokenString);
                this.decodedToken = this.jwtHelper.decodeToken(user.tokenString);
                console.log(this.decodedToken);
                this.userToken = user.tokenString;
            }
        });
    }

    register(model: any) {
        return this.http.post(this.baseUrl + 'register', model, this.requestOptions());
    }

    loggedIn() {
        return tokenNotExpired('token');
    }

    private requestOptions() {
        const headers = new Headers({'Content-type': 'application/json'});
        return new RequestOptions({headers: headers});
    }
}
