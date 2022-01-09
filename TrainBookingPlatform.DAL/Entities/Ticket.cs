using System;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Ticket : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int DepartureId { get; set; }
        public Departure Departure { get; set; }
        public DateTime DepartureDate { get; set; }
        public int SeatNumber { get; set; }
        public int WagonNumber { get; set; }
        public int Price { get; set; }
    }
}
