import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../models/doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  constructor(private http:HttpClient) { }
  GetDoctors(): Observable<any>{
    return this.http.get<any>("http://localhost:5041/api/Doctor/GetDoctor");
  }
  postDoctor(d: Doctor): Observable<Doctor>{
    return this.http.post<Doctor>("http://localhost:5041/api/Doctor/Insert",d);
  }
  updateDoctor(d:Doctor): Observable<Doctor>{
    return this.http.put<Doctor>("http://localhost:5041/api/Doctor/Update/"+d.DoctorID,d);
  }
  deleteDoctor(id:number): Observable<any>{
    return this.http.delete<any>("http://localhost:5041/api/Doctor/Delete/"+id);
  }
}
