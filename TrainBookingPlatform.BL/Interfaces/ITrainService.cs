using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface ITrainService
    {
        public Task<Result<TrainDTO>> Add(TrainDTO train);
        public Task<Train> Delete(int id);
        public Task<Result<TrainDTO>> Update(TrainDTO train);
        public Task<Result<TrainDTO>> Get(int id);
        public Task<IEnumerable<TrainDTO>> GetAll();
    }
}
