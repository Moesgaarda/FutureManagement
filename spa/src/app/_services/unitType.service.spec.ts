/* tslint:disable:no-unused-variable */

import {inject, TestBed} from '@angular/core/testing';
import {UnitTypeService} from './unitType.service';

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
