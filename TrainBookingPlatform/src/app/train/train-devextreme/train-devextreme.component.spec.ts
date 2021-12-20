import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainDevextremeComponent } from './train-devextreme.component';

describe('TrainDevextremeComponent', () => {
  let component: TrainDevextremeComponent;
  let fixture: ComponentFixture<TrainDevextremeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrainDevextremeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainDevextremeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
