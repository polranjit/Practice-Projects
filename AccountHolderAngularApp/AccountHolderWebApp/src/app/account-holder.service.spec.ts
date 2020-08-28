import { TestBed } from '@angular/core/testing';

import { AccountHolderService } from './account-holder.service';

describe('AccountHolderService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AccountHolderService = TestBed.get(AccountHolderService);
    expect(service).toBeTruthy();
  });
});
