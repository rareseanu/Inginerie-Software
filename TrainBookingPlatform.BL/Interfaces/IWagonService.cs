using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IWagonService
    {
        public Task<IEnumerable<WagonDTO>> GetAllByTrainId(int trainID);
    }
}
