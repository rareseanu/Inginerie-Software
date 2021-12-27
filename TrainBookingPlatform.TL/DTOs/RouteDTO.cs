using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TrainBookingPlatform.TL.DTOs
{
    public class RouteDTO : BaseDTO
    {
        public int? DestinationStationId { get; set; }
        public StationDTO DestinationStation { get; set; }
        public int? DepartureStationId { get; set; }
        public StationDTO DepartureStation { get; set; }
        public List<DepartureDTO> Departures { get; set; }
    }
}
