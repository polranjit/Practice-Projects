import { TestBed } from '@angular/core/testing';

import { DateAdapterService } from './date-adapter.service';

describe('DateAdapterService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DateAdapterService = TestBed.get(DateAdapterService);
    expect(service).toBeTruthy();
  });
});
