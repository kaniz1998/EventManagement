import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatModule } from './modules/mat/mat.module';
import { BedComponent } from './componenets/bed/bed.component';
import { BedService } from './service/bed.service';
import { PreoperativeDiagnosisComponent } from './componenets/preoperative-diagnosis/preoperative-diagnosis.component';
import { SurgeryComponent } from './componenets/surgery/surgery.component';
import { WardCabinComponent } from './componenets/ward-cabin/ward-cabin.component';
import { PreoperativeDiagnosisService } from './service/preoperative-diagnosis.service';
import { SurgeryService } from './service/surgery.service';
import { WardCabinService } from './service/ward-cabin.service';
import { NurseComponent } from './componenets/nurse/nurse.component';
import { NurseService } from './service/nurse.service';
import { DoctorComponent } from './componenets/doctor/doctor.component';
import { DoctorService } from './service/doctor.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeshboardModule } from './modules/deshboard/deshboard.module';
import { HrManagementModule } from './modules/hr-management.module';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    BedComponent,
    PreoperativeDiagnosisComponent,
    SurgeryComponent,
    WardCabinComponent,
    NurseComponent,
    DoctorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    DeshboardModule,
    HrManagementModule,
    ToastrModule.forRoot()

  ],
  providers: [
    BedService,
    PreoperativeDiagnosisService,
    SurgeryService,
    WardCabinService,
    NurseService,
    DoctorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
