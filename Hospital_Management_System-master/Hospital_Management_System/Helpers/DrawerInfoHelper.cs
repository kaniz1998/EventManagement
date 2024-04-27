using HMS.Models;

namespace Hospital_Management_System.Helpers
{
    public class DrawerInfoHelper
    {
        public DrawerInfoHelper() { }

        public DrawerInfoHelper(DrawerInfo drawerInfo)
        {
            this.DrawerInfoID = drawerInfo.DrawerID;
            this.ReceivedDate = drawerInfo.ReceivedDate;
            this.ReleaseDate = drawerInfo.ReleaseDate;
            this.IsPatient = drawerInfo.IsPatient;
            this.DrawerID = drawerInfo.DrawerID;
            this.PatientID = drawerInfo.PatientID;
            this.UnidentifiedDeadBodyID = drawerInfo.UnidentifiedDeadBodyID;
        }

        public int DrawerInfoID { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsPatient { get; set; }
        public int DrawerID { get; set; }
        public int? PatientID { get; set; }
        public int? UnidentifiedDeadBodyID { get; set; }

        public DrawerInfo GetDrawerInfo()
        {
            DrawerInfo drawerInfo = new DrawerInfo();
            drawerInfo.DrawerInfoID = this.DrawerInfoID;
            drawerInfo.ReceivedDate = this.ReceivedDate;
            drawerInfo.ReleaseDate = this.ReleaseDate;
            drawerInfo.IsPatient = this.IsPatient;
            drawerInfo.DrawerID = this.DrawerID;
            drawerInfo.PatientID = this.PatientID;
            drawerInfo.UnidentifiedDeadBodyID = this.UnidentifiedDeadBodyID;
            return drawerInfo;
        }
    }
}
