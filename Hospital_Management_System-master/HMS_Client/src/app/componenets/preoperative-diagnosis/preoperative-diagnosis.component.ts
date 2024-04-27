import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PreoperativeDiagnosis } from 'src/app/models/preoperative-diagnosis';
import { PreoperativeDiagnosisService } from 'src/app/service/preoperative-diagnosis.service';

@Component({
  selector: 'app-preoperative-diagnosis',
  templateUrl: './preoperative-diagnosis.component.html',
  styleUrls: ['./preoperative-diagnosis.component.css']
})
export class PreoperativeDiagnosisComponent {
  preoperativeDiagnosis: any;
  postPreoperativeDiagnosis: PreoperativeDiagnosis = {
    preoperativeDiagnosisId: undefined,
    preoperativeDiagnosisName: ''
  }
  constructor(private preoperativeDiagnosisService: PreoperativeDiagnosisService, private route: Router) { }
  ngOnInit() {
    this.GetAllPreoperativeDiagnosis();
  }

  GetAllPreoperativeDiagnosis() {
    this.preoperativeDiagnosisService.getAllPreoperativeDiagnosis().subscribe(b => {
      this.preoperativeDiagnosisService = b;
    });
  }
  insertPreoperativeDiagnosis() {
    if (this.postPreoperativeDiagnosis.preoperativeDiagnosisId === undefined) {
      this.preoperativeDiagnosisService.postPreoperativeDiagnosis(this.postPreoperativeDiagnosis).subscribe(p => {
        console.log(p);
        this.route.navigate(['/preoperativeDiagnosis']);
        this.GetAllPreoperativeDiagnosis();
        this.postPreoperativeDiagnosis = {
          preoperativeDiagnosisId: undefined,
          preoperativeDiagnosisName: ''
        }
      });
    }
    else {
      this.updatePreoperativeDiagnosis(this.postPreoperativeDiagnosis)
      this.postPreoperativeDiagnosis = {
        preoperativeDiagnosisId: undefined,
        preoperativeDiagnosisName: ''
      }
    }
  }
  updatePreoperativeDiagnosis(postBed: PreoperativeDiagnosis) {
    this.preoperativeDiagnosisService.updatePreoperativeDiagnosis(postBed).subscribe(up => {
      this.GetAllPreoperativeDiagnosis();
    });
  }
  // deletePreoperativeDiagnosis(id: number) {
  //   this.preoperativeDiagnosis.deletePreoperativeDiagnosis(id).subscribe(b => {
  //     this.route.navigate(['/preoperativeDiagnosis']);
  //     this.GetAllPreoperativeDiagnosis();
  //   })
  // }
  PopulateData(POP: PreoperativeDiagnosis) { this.postPreoperativeDiagnosis = POP }
}
