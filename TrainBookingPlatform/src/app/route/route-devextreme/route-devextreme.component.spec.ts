import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RouteDevextremeComponent } from './route-devextreme.component';

describe('RouteDevextremeComponent', () => {
  let component: RouteDevextremeComponent;
  let fixture: ComponentFixture<RouteDevextremeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RouteDevextremeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RouteDevextremeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
