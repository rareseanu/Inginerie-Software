using System;

namespace TrainBookingPlatform.DAL.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }

        public int UserId { get; set; }
    }
}
