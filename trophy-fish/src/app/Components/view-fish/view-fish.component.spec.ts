import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewFishComponent } from './view-fish.component';

describe('ViewFishComponent', () => {
  let component: ViewFishComponent;
  let fixture: ComponentFixture<ViewFishComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewFishComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewFishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
