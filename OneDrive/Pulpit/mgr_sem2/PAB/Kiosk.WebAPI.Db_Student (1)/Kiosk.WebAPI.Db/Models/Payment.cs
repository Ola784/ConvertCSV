namespace Kiosk.WebAPI.Db.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        CashOnDelivery,
        GiftCard
    }
    public class Payment
    {

        public int Id { get; set; }
        public Reservation ReservationId { get; set; }
        public int Amount { get; set; }

        public System.DateTime Created { get; set; }

        public PaymentMethod Method { get; set; }
    }
}
