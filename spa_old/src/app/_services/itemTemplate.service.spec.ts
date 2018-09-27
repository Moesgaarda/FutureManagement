/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ItemTemplateService } from './itemTemplate.service';

describe('Service: ItemTemplate', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ItemTemplateService]
    });
  });

  it('should ...', inject([ItemTemplateService], (service: ItemTemplateService) => {
    expect(service).toBeTruthy();
  }));
});
