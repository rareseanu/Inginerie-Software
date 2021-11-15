using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IUserService
    {
        public Task<User> Add(User user);
        public User Delete(int id);
        public User Update(User user);
        public User Get(int id);
        public Task<LoginResponseDTO> Login(string email, string password);
        public Task<LoginResponseDTO> RefreshToken(string refreshToken);
        public Task<User> Register(string email, string password);
        public IEnumerable<User> GetAll();
    }
}
