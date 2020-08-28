import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountHolderSearchComponent } from './account-holder-search.component';

describe('AccountHolderSearchComponent', () => {
  let component: AccountHolderSearchComponent;
  let fixture: ComponentFixture<AccountHolderSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountHolderSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountHolderSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
