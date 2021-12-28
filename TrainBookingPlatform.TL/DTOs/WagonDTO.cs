namespace TrainBookingPlatform.TL.DTOs
{
    public class WagonDTO : BaseDTO
    {
        public int Number { get; set; }
        public int NumberOfSeats { get; set; }
        public int TrainId { get; set; }
        public TrainDTO Train { get; set; }
    }
}
