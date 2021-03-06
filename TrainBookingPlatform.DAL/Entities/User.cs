using System.Collections.Generic;

namespace TrainBookingPlatform.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
