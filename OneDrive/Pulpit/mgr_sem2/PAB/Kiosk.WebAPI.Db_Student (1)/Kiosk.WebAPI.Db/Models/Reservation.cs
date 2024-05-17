namespace Kiosk.WebAPI.Db.Models
{
    public enum ReservationStatus
    {
        Pending_Payment,//przed oplaceniem
        Confirmed,
        Completed,
        Expired,
        Canceled
    }
    public class Reservation
    {
        public int Id { get; set; }
        public System.DateTime Created { get; set; }

        public System.DateTime StartDate { get; set; }
        public System.DateTime FinishDate { get; set; }

        double TotalCost { get; set; }

        public ReservationStatus Status { get; set; }

        public User UserId { get; set; }

        public Accomodation AccomodationId { get; set; }

        public Reservation(ReservationStatus status, DateTime date, User user, Accomodation accomodation)
        {
            Status = status;
            Created = date;
            UserId = user;
            AccomodationId = accomodation;
            
        }
    }
}
