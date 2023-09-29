import { TestBed } from '@angular/core/testing';

import { ShoesSeviceService } from './shoes-sevice.service';

describe('ShoesSeviceService', () => {
  let service: ShoesSeviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShoesSeviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
