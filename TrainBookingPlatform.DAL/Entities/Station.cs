using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Station : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfLines { get; set; }
        [InverseProperty("DestinationStation")]
        public List<Line> DestinationRoutes { get; set; }
        [InverseProperty("DepartureStation")]
        public List<Line> DepartureRoutes { get; set; }
    }
}
