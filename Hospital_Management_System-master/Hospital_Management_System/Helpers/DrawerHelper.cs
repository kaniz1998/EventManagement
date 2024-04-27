using HMS.Models;

namespace Hospital_Management_System.Helpers
{
    public class DrawerHelper
    {
        public DrawerHelper() { }
        public DrawerHelper(Drawer drawer) 
        {
            this.DrawerID = drawer.DrawerID;
            this.DrawerNo = drawer.DrawerNo;
            this.DrawerCondition = drawer.DrawerCondition;
            this.IsOccupied = drawer.IsOccupied;
            //this.DeceasedName = drawer.DeceasedName;
            //this.IsPatient = drawer.IsPatient;
            //this.PatientID = drawer.PatientID;
            //this.DateOfDeath = drawer.DateOfDeath;
            this.MorgueID = drawer.MorgueID;
        }

        public int DrawerID { get; set; }
        public string DrawerNo { get; set; }
        public DrawerCondition DrawerCondition { get; set; }
        public bool IsOccupied { get; set; }
        //public string? DeceasedName { get; set; }
        //public bool IsPatient { get; set; }
        //public int? PatientID { get; set; }
        //public DateTime? DateOfDeath { get; set; }
        public int MorgueID { get; set; }

        public Drawer GetDrawer()
        {
            Drawer drawer = new Drawer();
            drawer.DrawerID = this.DrawerID;
            drawer.DrawerNo = this.DrawerNo;
            drawer.DrawerCondition = this.DrawerCondition;
            drawer.IsOccupied = this.IsOccupied;
            //drawer.DeceasedName = this.DeceasedName;
            //drawer.IsPatient = this.IsPatient;
            //drawer.DateOfDeath= this.DateOfDeath;
            //drawer.PatientID = this.PatientID
            drawer.MorgueID= this.MorgueID;
            return drawer;
        }
    } 
}
