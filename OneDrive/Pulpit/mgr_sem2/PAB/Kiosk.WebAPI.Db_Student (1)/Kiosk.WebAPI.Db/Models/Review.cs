namespace Kiosk.WebAPI.Db.Models
{
    public enum Score
    {
        Excellent,
        Very_good,
        Good,
        Poor,
        Very_poor

    }
    public class Review
    {
        public int Id { get; set; }
        public Score score { get; set; }
        public string Description { get; set; }
        public User UserId { get; set; }
        public Accomodation AccomodationId { get; set; }
    }
}
