using System.ComponentModel.DataAnnotations.Schema;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Route : BaseEntity
    {
        [ForeignKey("DepartureStationID")]
        public Station DepartureStation { get; set; }
        [ForeignKey("ArrivalStationID")]
        public Station ArrivalStation { get; set; }
    }
}
