/* tslint:disable:no-unused-variable */

import {inject, TestBed} from '@angular/core/testing';
import {FileUploadService} from './fileUpload.service';

describe('Service: FileUpload', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FileUploadService]
    });
  });

  it('should ...', inject([FileUploadService], (service: FileUploadService) => {
    expect(service).toBeTruthy();
  }));
});
