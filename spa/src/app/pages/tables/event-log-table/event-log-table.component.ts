import { Component } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { EventLogService } from '../../../_services/eventLog.service';
import { LocalDataSource } from 'ng2-smart-table';
import { EventLog } from '../../../_models/eventLog';

@Component({
  selector: 'ngx-event-log-table',
  templateUrl: './event-log-table.component.html',
  styles: [`
  nb-card {
    transform: translate3d(0, 0, 0);
  }
`],
})
export class EventLogTableComponent {
  baseUrl = environment.spaUrl;
  source: LocalDataSource;
  eventLogs: EventLog [];


  settings = {
    pager: {
      perPage: 15,
    },
    mode: 'external',
    columns: {
      user: {
        title: 'Bruger',
        valuePrepareFunction: (temp) => {
          return temp.name.toString();
        },
        filterFunction(temp?: any, search?: string): boolean {
          const match = temp.name.indexOf(search) > -1
          if (match || search === '') {
            return true;
          } else {
            return false;
          }
        },
      },
      description: {
        title: 'Beskrivelse',
        type: 'string',
      },
      datetime: {
        title: 'Tidspunkt',
        type: 'string',
      },
    },
  };

  constructor(private eventLogService: EventLogService) {
    this.source = new LocalDataSource();
    this.loadEvents();
  }

  async loadEvents() {
    await this.eventLogService.getAllEventLogs().subscribe(eventLogs => {
      this.eventLogs = eventLogs;
      this.source.load(eventLogs);
      this.source.refresh();
    })
  }
}

