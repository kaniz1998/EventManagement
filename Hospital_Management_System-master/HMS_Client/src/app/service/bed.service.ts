import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bed } from '../models/bed';

@Injectable({
  providedIn: 'root'
})
export class BedService {

  constructor(private http:HttpClient) { }
  getAllBed(): Observable<any>{
    return this.http.get<any>("http://localhost:5041/api/Beds");
  }
  postBed(b: Bed): Observable<Bed>{
    return this.http.post<Bed>("http://localhost:5041/api/Beds",b);
  }
  updateBed(b:Bed): Observable<Bed>{
    return this.http.put<Bed>("http://localhost:5041/api/Beds/"+b.bedID,b);
  }
  deleteBed(id:number): Observable<any>{
    return this.http.delete<any>("http://localhost:5041/api/Beds"+id);
  }
}
