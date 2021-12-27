using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IUserService
    {
        public Task<Result<UserDTO>> Add(UserDTO user);
        public Task<User> Delete(int id);
        public Task<Result<UserDTO>> Update(UserDTO user);
        public Task<Result<UserDTO>> Get(int id);
        public Task<Result<LoginResponseDTO>> Login(string email, string password);
        public Task<Result<LoginResponseDTO>> RefreshToken(string refreshToken);
        public Task<Result<UserDTO>> Register(string email, string password);
        public Task<Result<IEnumerable<UserDTO>>> GetAll();
        public Task RevokeToken(string token);
    }
}
