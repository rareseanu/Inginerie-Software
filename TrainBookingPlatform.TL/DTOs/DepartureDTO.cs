using System;

namespace TrainBookingPlatform.TL.DTOs
{
    public class DepartureDTO
    {
        public int RouteId { get; set; }
        public RouteDTO Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int TrainId { get; set; }
        public TrainDTO Train { get; set; }
    }
}
