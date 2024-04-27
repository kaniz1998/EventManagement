import { TestBed } from '@angular/core/testing';

import { PreoperativeDiagnosisService } from './preoperative-diagnosis.service';

describe('PreoperativeDiagnosisService', () => {
  let service: PreoperativeDiagnosisService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PreoperativeDiagnosisService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
