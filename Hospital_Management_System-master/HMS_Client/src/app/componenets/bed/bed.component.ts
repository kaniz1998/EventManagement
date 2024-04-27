import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Bed } from 'src/app/models/bed';
import { BedService } from 'src/app/service/bed.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-bed',
  templateUrl: './bed.component.html',
  styleUrls: ['./bed.component.css']
})
export class BedComponent {
  Bed: any;
  postBed: Bed = {
    // bedId: undefined,
    // bedNumber: '',
    // isOccupid: true
    bedID: undefined,
    bedNumber: '',
    isOccupied: true
  }
  constructor(private bedSer: BedService, private route: Router) { }
  ngOnInit() {
    this.GetAllBed();
  }

  GetAllBed() {
    this.bedSer.getAllBed().subscribe(b => {
      this.bedSer = b;
    });
  }
  insertBed() {
    if (this.postBed.bedID === undefined) {
      this.bedSer.postBed(this.postBed).subscribe(p => {
        console.log(p);
        this.route.navigate(['/bed']);
        this.GetAllBed();
        this.postBed = {
          bedID: undefined,
          bedNumber: '',
          isOccupied: true
        }
      });
    }
    else {
      this.updateBed(this.postBed)
      this.postBed = {
        bedID: undefined,
        bedNumber: '',
        isOccupied: true
      }
    }
  }
  updateBed(postBed: Bed) {
    this.bedSer.updateBed(postBed).subscribe(up => {
      this.GetAllBed();
    });
  }
  deleteBed(id: number) {
    this.bedSer.deleteBed(id).subscribe(b => {
      this.route.navigate(['/bed']);
      this.GetAllBed();
    })
  }
  PopulateData(POP: Bed) { this.postBed = POP }

}
