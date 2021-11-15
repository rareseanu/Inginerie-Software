using System;

namespace TrainBookingPlatform.TL.DTOs
{
    public class LoginResponseDTO
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
