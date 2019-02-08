import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {EventLog} from '../_models/EventLog';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';


@Injectable()
export class EventLogService {

  baseUrl = environment.apiUrl + 'eventLogs/';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<EventLog[]> {
    return this.http.get<EventLog[]>(this.baseUrl + 'getAll/');
  }

  getUserEventLogs(id: number): Observable<EventLog[]> {
    return this.http.get<EventLog[]>(this.baseUrl + 'myEventLogs/' + id);
  }

  getMyEventLogs(id: number): Observable<EventLog[]> {
    return this.http.get<EventLog[]>(this.baseUrl + id);
  }
}
