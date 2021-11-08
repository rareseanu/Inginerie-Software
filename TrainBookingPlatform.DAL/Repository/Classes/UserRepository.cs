using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.DAL.Repository.Classes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TrainBookingPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
