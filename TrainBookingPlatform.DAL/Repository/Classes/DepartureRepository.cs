using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.DAL.Repository.Classes
{
    public class DepartureRepository : BaseRepository<Departure>, IDepartureRepository
    {
        public DepartureRepository(TrainBookingPlatformDbContext dbContext) : base(dbContext)
        {

        }
    }
}
