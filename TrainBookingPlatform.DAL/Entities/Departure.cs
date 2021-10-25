using System;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Departure : BaseEntity
    {
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
    }
}
