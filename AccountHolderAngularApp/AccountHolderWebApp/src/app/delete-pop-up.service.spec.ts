import { TestBed } from '@angular/core/testing';

import { DeletePopUpService } from './delete-pop-up.service';

describe('DeletePopUpService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DeletePopUpService = TestBed.get(DeletePopUpService);
    expect(service).toBeTruthy();
  });
});
