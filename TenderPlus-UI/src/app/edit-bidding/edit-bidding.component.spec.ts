import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBiddingComponent } from './edit-bidding.component';

describe('EditBiddingComponent', () => {
  let component: EditBiddingComponent;
  let fixture: ComponentFixture<EditBiddingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditBiddingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditBiddingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
