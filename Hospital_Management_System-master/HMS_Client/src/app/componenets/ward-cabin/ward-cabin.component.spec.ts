import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WardCabinComponent } from './ward-cabin.component';

describe('WardCabinComponent', () => {
  let component: WardCabinComponent;
  let fixture: ComponentFixture<WardCabinComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WardCabinComponent]
    });
    fixture = TestBed.createComponent(WardCabinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
