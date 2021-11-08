using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.DAL.Repository.Classes
{
    public class StationRepository : BaseRepository<Station>, IStationRepository
    {
        public StationRepository(TrainBookingPlatformDbContext dbContext) : base(dbContext)
        {

        }
    }
}
