import { TestBed } from '@angular/core/testing';

import { DateformatterService } from './dateformatter.service';

describe('DateformatterService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DateformatterService = TestBed.get(DateformatterService);
    expect(service).toBeTruthy();
  });
});
