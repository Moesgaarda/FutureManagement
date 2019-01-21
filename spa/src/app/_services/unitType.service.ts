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


    // TODO Should be moved to ItemTemplate repo
    getAll(): Observable<UnitType[]> {
        return this.http.get<UnitType[]>(this.baseUrl + 'UnitTypes/getAll');
    }

    // TODO Should be moved to ItemTemplate repo
    addUnitType(unitType: UnitType): Observable<UnitType> {
        return this.http.post<UnitType>(this.baseUrl + 'ItemTemplate/addUnitType', unitType, this.httpOptions);
    }

    getUnitType(id: number): Observable<Order> {
        return this.http.get<Order>(this.baseUrl + 'UnitType/get/' + id);
    }

    editUnitType(unitType: UnitType): Observable<UnitType> {
        return this.http.post<UnitType>(this.baseUrl + 'UnitType/edit', unitType, this.httpOptions);
    }

}
