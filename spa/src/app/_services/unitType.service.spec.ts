/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UnitTypeService } from './unitType.service';

describe('Service: UnitType', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UnitTypeService]
    });
  });

  it('should ...', inject([UnitTypeService], (service: UnitTypeService) => {
    expect(service).toBeTruthy();
  }));
});
