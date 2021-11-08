using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.DAL.Repository.Classes
{
    public class TrainRepository : BaseRepository<Train>
    {
        public TrainRepository(TrainBookingPlatformDbContext dbContext) : base(dbContext)
        {

        }
    }
}
