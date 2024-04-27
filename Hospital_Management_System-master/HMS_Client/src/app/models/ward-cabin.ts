export class WardCabin {
    constructor(
        public wardCabinId?: number,
        public wardCabinName?: string,
        public wardCabinType?: WardCabinType
    ){}
}
export enum WardCabinType {
    Regular = 1,
    VIP = 2,
    ICU = 3,
    // Add more types as needed
  }
  
