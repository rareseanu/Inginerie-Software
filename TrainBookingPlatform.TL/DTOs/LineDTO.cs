using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TrainBookingPlatform.TL.DTOs
{
    public class LineDTO : BaseDTO
    {
        public int RouteId { get; set; }
        public RouteDTO Route { get; set; }
        public int? DestinationStationId { get; set; }
        public StationDTO DestinationStation { get; set; }
        public int? DepartureStationId { get; set; }
        public StationDTO DepartureStation { get; set; }
        public List<DepartureDTO> Departures { get; set; }
    }
}
