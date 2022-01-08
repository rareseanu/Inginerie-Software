import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LineDevextremeComponent } from './line-devextreme.component';

describe('LineDevextremeComponent', () => {
  let component: LineDevextremeComponent;
  let fixture: ComponentFixture<LineDevextremeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LineDevextremeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LineDevextremeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
