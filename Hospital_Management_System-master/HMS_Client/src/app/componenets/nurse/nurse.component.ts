import { Component } from '@angular/core';
import { Nurse } from '../../models/nurse';
import { NurseService } from '../../service/nurse.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nurse',
  templateUrl: './nurse.component.html',
  styleUrls: ['./nurse.component.css']
})
export class NurseComponent {
  Nurse: any;
  postNurse: Nurse = {
    nurseId: undefined,
    nurseName: '',
    nurseLevel: undefined,
    nurseType: undefined,
    joinDate: undefined,
    resignDate: undefined,
    employeeStatus: undefined,
    educationInfo: '',
    image: '',
    phoneNumber: ''
  }
  constructor(private nurseSerice: NurseService, private route: Router) { }
  ngOnInit() {
    this.GetAllNurse();
  }

  GetAllNurse() {
    this.nurseSerice.getAllNurse().subscribe(b => {
      this.nurseSerice = b;
    });
  }
  insertNurse() {
    if (this.postNurse.nurseId === undefined) {
      this.nurseSerice.postNurse(this.postNurse).subscribe(p => {
        console.log(p);
        this.route.navigate(['/nurse']);
        this.GetAllNurse();
        this.postNurse = {
          nurseId: undefined,
          nurseName: '',
          nurseLevel: undefined,
          nurseType: undefined,
          joinDate: undefined,
          resignDate: undefined,
          employeeStatus: undefined,
          educationInfo: '',
          image: '',
          phoneNumber: ''
        }
      });
    }
    else {
      this.updateNurse(this.postNurse)
      this.postNurse = {
        nurseId: undefined,
        nurseName: '',
        nurseLevel: undefined,
        nurseType: undefined,
        joinDate: undefined,
        resignDate: undefined,
        employeeStatus: undefined,
        educationInfo: '',
        image: '',
        phoneNumber: ''
      }
    }
  }
  updateNurse(postNurse: Nurse) {
    this.nurseSerice.updateNurse(postNurse).subscribe(up => {
      this.GetAllNurse();
    });
  }
  deleteNurse(id: number) {
    this.nurseSerice.deleteNurse(id).subscribe(b => {
      this.route.navigate(['/nurse']);
      this.GetAllNurse();
    })
  }
  PopulateData(POP: Nurse) { this.postNurse = POP }
}
