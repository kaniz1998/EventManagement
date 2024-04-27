import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Surgery } from 'src/app/models/surgery';
import { SurgeryService } from 'src/app/service/surgery.service';

@Component({
  selector: 'app-surgery',
  templateUrl: './surgery.component.html',
  styleUrls: ['./surgery.component.css']
})
export class SurgeryComponent {
  Surgery: any;
  postSurgery: Surgery = {
    surgeryId: undefined,
    surgeryType: undefined,
    surgeryDate: undefined,
    observations:'',
    Postoperative_Diagnosis:''
  }
  constructor(private surgeryService: SurgeryService, private route: Router) { }
  ngOnInit() {
    this.GetAllSurgery();
  }

  GetAllSurgery() {
    this.surgeryService.getAllSurgery().subscribe(b => {
      this.surgeryService = b;
    });
  }
  insertSurgery() {
    if (this.postSurgery.surgeryId === undefined) {
      this.surgeryService.postSurgery(this.postSurgery).subscribe(p => {
        console.log(p);
        this.route.navigate(['/surgery']);
        this.GetAllSurgery();
        this.postSurgery = {
          surgeryId: undefined,
          surgeryType: undefined,
          surgeryDate: undefined,
          observations:'',
          Postoperative_Diagnosis:''
        }
      });
    }
    else {
      this.updateSurgery(this.postSurgery)
      this.postSurgery = {
        surgeryId: undefined,
        surgeryType: undefined,
        surgeryDate: undefined,
        observations:'',
        Postoperative_Diagnosis:''
      }
    }
  }
  updateSurgery(postSurgery: Surgery) {
    this.surgeryService.updateSurgery(postSurgery).subscribe(up => {
      this.GetAllSurgery();
    });
  }
  deleteSurgery(id: number) {
    this.surgeryService.deleteSurgery(id).subscribe(b => {
      this.route.navigate(['/surgery']);
      this.GetAllSurgery();
    })
  }
  PopulateData(POP: Surgery) { this.postSurgery = POP }
}
