using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.BL.Classes
{
    public class StationService : IStationService
    {
        private IStationRepository _stationRepository;

        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Station> Add(Station station)
        {
            return await _stationRepository.Create(station);
        }

        public Station Delete(int id)
        {
            Station station = _stationRepository.Get(p => p.Id == id).FirstOrDefault();
            if (station != null)
            {
                return _stationRepository.Delete(station);
            }
            return null;
        }

        public Station Update(Station station)
        {
            return _stationRepository.Update(station);
        }

        public Station Get(int id)
        {
            return _stationRepository.Get(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Station> GetAll()
        {
            return _stationRepository.GetAll();
        }
    }
}
