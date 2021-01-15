import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YourTenderComponent } from './your-tender.component';

describe('YourTenderComponent', () => {
  let component: YourTenderComponent;
  let fixture: ComponentFixture<YourTenderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YourTenderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YourTenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
