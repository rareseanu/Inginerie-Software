using System;
using System.Collections.Generic;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Departure : BaseEntity
    {
        public int LineId { get; set; }
        public Line Line { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
