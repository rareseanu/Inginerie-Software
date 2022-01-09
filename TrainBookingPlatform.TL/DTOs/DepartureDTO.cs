using System;

namespace TrainBookingPlatform.TL.DTOs
{
    public class DepartureDTO : BaseDTO
    {
        public int LineId { get; set; }
        public LineDTO Line{ get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int TrainId { get; set; }
        public TrainDTO Train { get; set; }

    }
}
