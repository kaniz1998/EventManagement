import { Component } from '@angular/core';
import { Doctor } from '../../models/doctor';
import { DoctorService } from '../../service/doctor.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent {
  Doctor: any;
  postDoctor: Doctor = {
    DoctorID: undefined,
    DoctorName: '',
    DepartmentID: undefined,
    Specialization: undefined,
    Doctortype: undefined,
    JoinDate: undefined,
    ResignDate: undefined,
    EmployeeStatus: undefined,
    Education_Info: "",
    PhoneNumber: "",
    Image: "",
    Department: undefined,
    Prescriptions: undefined,
    Appointments: undefined,
  }
  constructor(private doctorService: DoctorService, private route: Router) { }
  ngOnInit() {
    this.GetAllDoctor();
  }

  GetAllDoctor() {
    this.doctorService.GetDoctors().subscribe(docSer => {
      this.doctorService = docSer;
    });
  }

  insertDoctor() {
    if (this.postDoctor.DoctorID === undefined) {
      this.doctorService.postDoctor(this.postDoctor).subscribe(pd => {
        console.log(pd);
        this.route.navigate(['/doctor']);
        this.GetAllDoctor();
        this.postDoctor = {
          DoctorID: undefined,
          DoctorName: '',
          DepartmentID: undefined,
          Specialization: undefined,
          Doctortype: undefined,
          JoinDate: undefined,
          ResignDate: undefined,
          EmployeeStatus: undefined,
          Education_Info: "",
          PhoneNumber: "",
          Image: "",
          Department: undefined,
          Prescriptions: undefined,
          Appointments: undefined,
        }
      });
    }
    else {
      this.updateDoctor(this.postDoctor)
      this.postDoctor = {
        DoctorID: undefined,
        DoctorName: '',
        DepartmentID: undefined,
        Specialization: undefined,
        Doctortype: undefined,
        JoinDate: undefined,
        ResignDate: undefined,
        EmployeeStatus: undefined,
        Education_Info: "",
        PhoneNumber: "",
        Image: "",
        Department: undefined,
        Prescriptions: undefined,
        Appointments: undefined,
      }
    }
  }
  updateDoctor(postDoctor: Doctor) {
    this.doctorService.updateDoctor(postDoctor).subscribe(up => {
      this.GetAllDoctor();
    });
  }
  deleteDoctor(id: number) {
    this.doctorService.deleteDoctor(id).subscribe(b => {
      this.route.navigate(['/doctor']);
      this.GetAllDoctor();
    })
  }
  PopulateData(POP: Doctor) { this.postDoctor = POP }
}
