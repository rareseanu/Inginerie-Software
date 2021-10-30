using System.Collections.Generic;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Seat : BaseEntity
    {
        public int Number { get; set; }
        public int? WagonId { get; set; }
        public Wagon Wagon { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
