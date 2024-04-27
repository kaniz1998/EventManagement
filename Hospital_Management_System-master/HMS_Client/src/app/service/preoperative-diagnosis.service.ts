import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PreoperativeDiagnosis } from '../models/preoperative-diagnosis';

@Injectable({
  providedIn: 'root'
})
export class PreoperativeDiagnosisService {

  constructor(private http:HttpClient) { }
  getAllPreoperativeDiagnosis(): Observable<any>{
    return this.http.get<any>("http://localhost:5041/api/PreoperativeDiagnosis");
  }
  postPreoperativeDiagnosis(b: PreoperativeDiagnosis): Observable<PreoperativeDiagnosis>{
    return this.http.post<PreoperativeDiagnosis>("http://localhost:5041/api/PreoperativeDiagnosis",b);
  }
  updatePreoperativeDiagnosis(b:PreoperativeDiagnosis): Observable<PreoperativeDiagnosis>{
    return this.http.put<PreoperativeDiagnosis>("http://localhost:5041/api/PreoperativeDiagnosis/"+b.preoperativeDiagnosisId,b);
  }
  deleteedPreoperativeDiagnosis(id:number): Observable<any>{
    return this.http.delete<any>("http://localhost:5041/api/PreoperativeDiagnosis"+id);
  }
}
