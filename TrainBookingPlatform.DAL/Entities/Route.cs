using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Route : BaseEntity
    {
        public int? DestinationStationId { get; set; }
        public Station DestinationStation { get; set; }
        public int? DepartureStationId { get; set; }
        public Station DepartureStation { get; set; }
        public List<Departure> Departures { get; set; }
    }
}
