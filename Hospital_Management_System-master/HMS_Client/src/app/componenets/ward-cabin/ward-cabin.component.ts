import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WardCabin } from 'src/app/models/ward-cabin';
import { WardCabinService } from 'src/app/service/ward-cabin.service';

@Component({
  selector: 'app-ward-cabin',
  templateUrl: './ward-cabin.component.html',
  styleUrls: ['./ward-cabin.component.css']
})
export class WardCabinComponent {
  WardCabin: any;
  postWardCabin: WardCabin = {
    wardCabinId: undefined,
    wardCabinName: '',
    wardCabinType: undefined
  }
  constructor(private wardCabinService: WardCabinService, private route: Router) { }
  ngOnInit() {
    this.GetAllWardCabin();
  }

  GetAllWardCabin() {
    this.wardCabinService.getAllWardCabin().subscribe(b => {
      this.wardCabinService = b;
    });
  }
  insertWardCabin() {
    if (this.postWardCabin.wardCabinId === undefined) {
      this.wardCabinService.postWardCabin(this.postWardCabin).subscribe(p => {
        console.log(p);
        this.route.navigate(['/wardCabin']);
        this.GetAllWardCabin();
        this.postWardCabin = {
          wardCabinId: undefined,
          wardCabinName: '',
          wardCabinType: undefined
        }
      });
    }
    else {
      this.updateWardCabin(this.postWardCabin)
      this.postWardCabin = {
        wardCabinId: undefined,
        wardCabinName: '',
        wardCabinType: undefined
      }
    }
  }
  updateWardCabin(postBed: WardCabin) {
    this.wardCabinService.updateWardCabin(postBed).subscribe(up => {
      this.GetAllWardCabin();
    });
  }
  deleteWardCabin(id: number) {
    this.wardCabinService.deleteWardCabin(id).subscribe(b => {
      this.route.navigate(['/wardCabin']);
      this.GetAllWardCabin();
    })
  }
  PopulateData(POP: WardCabin) { this.postWardCabin = POP }
}
