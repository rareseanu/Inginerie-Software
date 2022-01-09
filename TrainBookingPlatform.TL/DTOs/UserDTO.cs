namespace TrainBookingPlatform.TL.DTOs
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public int RoleId { get; set; }
        
    }
}
