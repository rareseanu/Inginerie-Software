import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketDevextremeComponent } from './ticket-devextreme.component';

describe('TicketDevextremeComponent', () => {
  let component: TicketDevextremeComponent;
  let fixture: ComponentFixture<TicketDevextremeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketDevextremeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketDevextremeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
