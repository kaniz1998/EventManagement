export class Surgery {
    constructor(
        public surgeryId?: number,
        public surgeryType?: surgeryType,
        public surgeryDate?: Date,
        public observations?: string,
        public Postoperative_Diagnosis?: string
    ){}
}
export enum surgeryType {
    Regular = 1,
    VIP = 2,
    ICU = 3,
    // Add more types as needed
  }
  
