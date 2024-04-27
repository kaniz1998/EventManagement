import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Constants } from '../Helper/constants';

import { DepartmentInfoModel } from '../models/depatmentModel';
import { ResponseModel } from '../models/responseModel';



@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  public departmentInfoModel:DepartmentInfoModel=new DepartmentInfoModel();
  constructor(private httpClient:HttpClient,private toastr:ToastrService) { }

  private readonly department:string=Constants.API_KEY+"api/Departments/";


  public insert(){
    return this.httpClient.post<ResponseModel>("http://localhost:5041/api/Departments/Insert",this.departmentInfoModel);

  }
 
  public  update (){
    
    return this.httpClient.put<ResponseModel>(this.department+"Update", this.departmentInfoModel);

  }

  public getAll()
  {
    return this.httpClient.get<ResponseModel>("http://localhost:5041/api/Departments/GetAll");
  }

  public delete(id:number){
    return this.httpClient.delete(`${this.department}${id}`)
  }
}
