import { TestBed } from '@angular/core/testing';

import { WardCabinService } from './ward-cabin.service';

describe('WardCabinService', () => {
  let service: WardCabinService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WardCabinService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
