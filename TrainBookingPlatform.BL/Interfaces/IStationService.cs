using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IStationService
    {
        public Task<Station> Add(Station station);
        public Station Delete(int id);
        public Station Update(Station station);
        public Station Get(int id);
        public IEnumerable<Station> GetAll();
    }
}
