using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.DAL.Repository.Classes
{
    public class LineRepository : BaseRepository<Line>, ILineRepository
    {
        public LineRepository(TrainBookingPlatformDbContext dbContext) : base(dbContext)
        {

        }
    }
}
