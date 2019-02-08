/* tslint:disable:no-unused-variable */

import {inject, TestBed} from '@angular/core/testing';
import {OrderService} from './order.service';

describe('Service: Order', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OrderService],
    });
  });

  it('should ...', inject([OrderService], (service: OrderService) => {
    expect(service).toBeTruthy();
  }));
});
