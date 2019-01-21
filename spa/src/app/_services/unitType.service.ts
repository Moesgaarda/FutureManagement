import { Injectable } from '@angular/core';
import { Order } from '../_models/Order';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { promise } from 'protractor';
import { UnitType } from '../_models/UnitType';
import { Item } from '../_models/Item';

@Injectable()
export class UnitTypeService {

    baseUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type':  'application/json',
            'Access-Control-Allow-Origin': '*',
        }),
    };

    constructor(private http: HttpClient) {}


    getAll(): Observable<UnitType[]> {
        return this.http.get<UnitType[]>(this.baseUrl + 'UnitType/getAll');
    }

    getUnitType(id: number): Observable<UnitType> {
        return this.http.get<UnitType>(this.baseUrl + 'UnitType/get/' + id);
    }

    addUnitType(unitType: UnitType): Observable<UnitType> {
        return this.http.post<UnitType>(this.baseUrl + 'UnitType/add', unitType, this.httpOptions);
    }

    editUnitType(unitType: UnitType): Observable<UnitType> {
        return this.http.post<UnitType>(this.baseUrl + 'UnitType/edit', unitType, this.httpOptions);
    }

}
