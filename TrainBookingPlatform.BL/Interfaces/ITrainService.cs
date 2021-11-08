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
        public Train Delete(int id);
        public Train Update(Train train);
        public Train Get(int id);
        public IEnumerable<Train> GetAll();
    }
}
