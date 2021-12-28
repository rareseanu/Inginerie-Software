using System;

namespace TrainBookingPlatform.TL.DTOs
{
    public class TicketDTO : BaseDTO
    {
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int DepartureId { get; set; }
        public DepartureDTO Departure { get; set; }
        public int SeatNumber { get; set; }
        public int Price { get; set; }
    }
}
