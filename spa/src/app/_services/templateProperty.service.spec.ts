/* tslint:disable:no-unused-variable */

import {inject, TestBed} from '@angular/core/testing';
import {TemplatePropertyService} from './templateProperty.service';

describe('Service: TemplateProperty', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TemplatePropertyService]
    });
  });

  it('should ...', inject([TemplatePropertyService], (service: TemplatePropertyService) => {
    expect(service).toBeTruthy();
  }));
});
