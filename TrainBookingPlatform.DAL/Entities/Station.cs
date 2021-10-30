using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Station : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfLines { get; set; }
        [InverseProperty("DestinationStation")]
        public List<Route> DestinationRoutes { get; set; }
        [InverseProperty("DepartureStation")]
        public List<Route> DepartureRoutes { get; set; }
    }
}
