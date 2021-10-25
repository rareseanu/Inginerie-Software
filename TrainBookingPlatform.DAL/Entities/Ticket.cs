﻿using System;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Ticket : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int DepartureId { get; set; }
        public Departure Departure { get; set; }
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
        public int Price { get; set; }
    }
}
