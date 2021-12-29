using System.Collections.Generic;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Line : BaseEntity
    {
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int? DestinationStationId { get; set; }
        public Station DestinationStation { get; set; }
        public int? DepartureStationId { get; set; }
        public Station DepartureStation { get; set; }
        public List<Departure> Departures { get; set; }
    }
}
