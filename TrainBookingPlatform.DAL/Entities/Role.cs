using System.Collections.Generic;

namespace TrainBookingPlatform.DAL.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
