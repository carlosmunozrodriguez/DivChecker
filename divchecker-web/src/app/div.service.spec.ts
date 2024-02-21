import { TestBed } from '@angular/core/testing';

import { DivService } from './div.service';

describe('DivService', () => {
  let service: DivService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DivService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
