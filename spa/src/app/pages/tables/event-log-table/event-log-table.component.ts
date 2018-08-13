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
          return temp.username.toString();
            }
      },
      description: {
        title: 'Beskrivelse',
        type: 'string',
      },
      time: {
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
