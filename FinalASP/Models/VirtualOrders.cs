namespace FinalASP.Models
{
    public class VirtualOrders
    {
        public int Id { get; set; }
        public string order { get; set; }
        public string OrderSource { get; set; }
        public string Orderdestination { get; set; }
        public double OrderPrice { get; set; }
        public int ReservationID { get; set; }
        public Reservations Reservation { get; set; }
    }
}
