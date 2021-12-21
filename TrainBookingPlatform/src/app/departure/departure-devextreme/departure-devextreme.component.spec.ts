import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartureDevextremeComponent } from './departure-devextreme.component';

describe('DepartureDevextremeComponent', () => {
  let component: DepartureDevextremeComponent;
  let fixture: ComponentFixture<DepartureDevextremeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepartureDevextremeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartureDevextremeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
