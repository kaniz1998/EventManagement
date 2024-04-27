import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WardCabin } from '../models/ward-cabin';

@Injectable({
  providedIn: 'root'
})
export class WardCabinService {

  constructor(private http:HttpClient) { }
  getAllWardCabin(): Observable<any>{
    return this.http.get<any>("http://localhost:5041/api/WardCabin");
  }
  postWardCabin(b: WardCabin): Observable<WardCabin>{
    return this.http.post<WardCabin>("http://localhost:5041/api/WardCabin",b);
  }
  updateWardCabin(b:WardCabin): Observable<WardCabin>{
    return this.http.put<WardCabin>("http://localhost:5041/api/WardCabin/"+b.wardCabinId,b);
  }
  deleteWardCabin(id:number): Observable<any>{
    return this.http.delete<any>("http://localhost:5041/api/WardCabin"+id);
  }
}
