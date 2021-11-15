import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserBudgetComponent } from './user-budget.component';

describe('UserBudgetComponent', () => {
  let component: UserBudgetComponent;
  let fixture: ComponentFixture<UserBudgetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserBudgetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserBudgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
