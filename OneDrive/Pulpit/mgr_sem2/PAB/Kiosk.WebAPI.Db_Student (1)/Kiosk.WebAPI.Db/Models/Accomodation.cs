namespace Kiosk.WebAPI.Db.Models
{
    public enum AccomodationType
    {
        Single_Room,
        Double_Room,
        Shared_Room,
        Dormitory,
        Hostel_Room,
        Bed_And_Breakfast


    }
    public class Accomodation
    {
        public int Id { get; set; }
        public System.DateTime Created { get; set; }

        double Cost_Per_Night { get; set; }

        public AccomodationType Type { get; set; }

    }
}
