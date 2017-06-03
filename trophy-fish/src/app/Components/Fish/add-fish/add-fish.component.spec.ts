import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFishComponent } from './add-fish.component';

describe('AddFishComponent', () => {
  let component: AddFishComponent;
  let fixture: ComponentFixture<AddFishComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddFishComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddFishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
