namespace TrainBookingPlatform.TL.DTOs
{
    public class TrainDTO : BaseDTO
    {
        public int Number { get; set; }
        public int WagonCount { get; set; }
        public int TotalNumberOfSeats { get; set; }
    }
}
