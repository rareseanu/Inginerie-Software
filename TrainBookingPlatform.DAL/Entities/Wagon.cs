using System.Collections.Generic;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Wagon : BaseEntity
    {
        public int Number { get; set; }
        public int NumberOfSeats { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
    }
}
