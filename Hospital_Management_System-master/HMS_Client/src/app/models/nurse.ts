export class Nurse {
    constructor(
        public nurseId?: number,
        public nurseName?: string,
        public nurseLevel?: NurseLevel,
        public nurseType?: NurseType,
        public joinDate?: Date,
        public resignDate?: Date,
        public employeeStatus?: EmployeeStatus,
        public educationInfo?: string,
        public image?: string,
        public phoneNumber?: string,
    ){}
}
export enum NurseLevel {
    Junior = 1,
    Intermediate,
    Senior,
    HeadNurse,
    Intern,
    Other
}
  export enum NurseType {
    General = 1,
    WardDuty,
    Midwife,
    Pediatric,
    OT,
    HDU,
}
export enum EmployeeStatus {
    active = 1,
    pending,
    abroad,
    leave,
}
  
