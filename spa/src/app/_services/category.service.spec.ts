/* tslint:disable:no-unused-variable */

import {inject, TestBed} from '@angular/core/testing';
import {CategoryService} from './category.service';

describe('Service: Category', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CategoryService]
    });
  });

  it('should ...', inject([CategoryService], (service: CategoryService) => {
    expect(service).toBeTruthy();
  }));
});
