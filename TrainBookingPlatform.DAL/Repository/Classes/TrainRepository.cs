using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.DAL.Repository.Classes
{
    public class TrainRepository : BaseRepository<Train> , ITrainRepository
    {
        public TrainRepository(TrainBookingPlatformDbContext dbContext) : base(dbContext)
        {

        }
    }
}
