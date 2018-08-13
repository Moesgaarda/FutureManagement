/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EventLogService } from './eventLog.service';

describe('Service: EventLog', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EventLogService]
    });
  });

  it('should ...', inject([EventLogService], (service: EventLogService) => {
    expect(service).toBeTruthy();
  }));
});
