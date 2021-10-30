namespace TrainBookingPlatform.TL.DTOs
{
    public class WagonDTO
    {
        public int Number { get; set; }
        public int TrainId { get; set; }
        public TrainDTO Train { get; set; }
    }
}
