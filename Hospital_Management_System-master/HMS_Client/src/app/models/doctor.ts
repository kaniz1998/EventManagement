export class Doctor {
    constructor(
        public DoctorName?: string,
        public DepartmentID?: number,
        public Specialization?: string,
        public Doctortype?: Doctortype,
        public JoinDate?: Date,
        public DoctorID?: number,
        public ResignDate?: Date,
        public EmployeeStatus?: EmployeeStatus,
        public Education_Info?: string,
        public PhoneNumber?: string,
        public Image?: string,
        public Department?: [],
        public Prescriptions?: [],
        public Appointments?: []
    ) {}
}

export enum Doctortype {
    generalpractitioner = 1,
    surgeon,
    anesthesiologist,
    dentist,
    Pathologist,
    Radiologists,
    specialist, 
}

export enum EmployeeStatus {
    active = 1,
    pending,
    abroad,
    leave,
}
