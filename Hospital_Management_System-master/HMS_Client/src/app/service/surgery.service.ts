import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Surgery } from '../models/surgery';

@Injectable({
  providedIn: 'root'
})
export class SurgeryService {

  constructor(private http:HttpClient) { }
  getAllSurgery(): Observable<any>{
    return this.http.get<any>("http://localhost:5041/api/Surgery");
  }
  postSurgery(b: Surgery): Observable<Surgery>{
    return this.http.post<Surgery>("http://localhost:5041/api/Surgery",b);
  }
  updateSurgery(b:Surgery): Observable<Surgery>{
    return this.http.put<Surgery>("http://localhost:5041/api/Surgery/"+b.surgeryId,b);
  }
  deleteSurgery(id:number): Observable<any>{
    return this.http.delete<any>("http://localhost:5041/api/Surgery"+id);
  }
}
