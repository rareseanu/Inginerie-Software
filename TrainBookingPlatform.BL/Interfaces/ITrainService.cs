using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface ITrainService
    {
        public Task<Train> Add(Train train);
        public Task<Train> Delete(int id);
        public Task<Train> Update(Train train);
        public Task<Train> Get(int id);
        public Task<IEnumerable<Train>> GetAll();
    }
}
