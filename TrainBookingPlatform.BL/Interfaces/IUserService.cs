using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IUserService
    {
        public Task<User> Add(User user);
        public User Delete(int id);
        public User Update(User user);
        public User Get(int id);
        public IEnumerable<User> GetAll();
    }
}
