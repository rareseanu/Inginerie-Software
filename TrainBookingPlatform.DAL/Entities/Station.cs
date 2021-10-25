namespace TrainBookingPlatform.DAL.Entities
{
    public class Station : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfLines { get; set; }
    }
}
