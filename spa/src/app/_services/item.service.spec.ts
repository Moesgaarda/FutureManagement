/* tslint:disable:no-unused-variable */

import {inject, TestBed} from '@angular/core/testing';
import {ItemService} from './item.service';

describe('Service: Item', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ItemService],
    });
  });

  it('should ...', inject([ItemService], (service: ItemService) => {
    expect(service).toBeTruthy();
  }));
});
