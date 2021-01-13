import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewBiddingComponent } from './view-bidding.component';

describe('ViewBiddingComponent', () => {
  let component: ViewBiddingComponent;
  let fixture: ComponentFixture<ViewBiddingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewBiddingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewBiddingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
