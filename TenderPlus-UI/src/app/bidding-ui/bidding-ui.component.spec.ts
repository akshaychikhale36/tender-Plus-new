import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BiddingUiComponent } from './bidding-ui.component';

describe('BiddingUiComponent', () => {
  let component: BiddingUiComponent;
  let fixture: ComponentFixture<BiddingUiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BiddingUiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BiddingUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
