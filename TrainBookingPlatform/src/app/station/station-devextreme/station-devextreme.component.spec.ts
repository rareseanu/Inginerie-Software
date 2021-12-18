import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationDevextremeComponent } from './station-devextreme.component';

describe('StationDevextremeComponent', () => {
  let component: StationDevextremeComponent;
  let fixture: ComponentFixture<StationDevextremeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StationDevextremeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StationDevextremeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
