import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Nurse } from '../models/nurse';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class NurseService {

  constructor(private http:HttpClient) { }
  getAllNurse(): Observable<any>{
    return this.http.get<any>("http://localhost:5041/api/Nurses/GetNurse");
  }
  postNurse(b: Nurse): Observable<Nurse>{
    return this.http.post<Nurse>("http://localhost:5041/api/Nurses/Insert",b);
  }
  updateNurse(b:Nurse): Observable<Nurse>{
    return this.http.put<Nurse>("http://localhost:5041/api/Nurses/Update/"+b.nurseId,b);
  }
  deleteNurse(id:number): Observable<any>{
    return this.http.delete<any>("http://localhost:5041/api/Nurses/Delete/"+id);
  }
}
