import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreoperativeDiagnosisComponent } from './preoperative-diagnosis.component';

describe('PreoperativeDiagnosisComponent', () => {
  let component: PreoperativeDiagnosisComponent;
  let fixture: ComponentFixture<PreoperativeDiagnosisComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PreoperativeDiagnosisComponent]
    });
    fixture = TestBed.createComponent(PreoperativeDiagnosisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
