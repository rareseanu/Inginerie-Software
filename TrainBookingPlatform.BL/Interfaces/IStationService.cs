using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IStationService
    {
        public Task<Station> Add(Station station);
        public Task<Station> Delete(int id);
        public Task<Station> Update(Station station);
        public Task<Station> Get(int id);
        public Task<IEnumerable<Station>> GetAll();
    }
}
