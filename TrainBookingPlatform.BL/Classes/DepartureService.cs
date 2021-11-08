using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.BL.Classes
{
    public class DepartureService : IDepartureService
    {
        private IDepartureRepository _departureRepository;

        public DepartureService(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public async Task<Departure> Add(Departure departure)
        {
            return await _departureRepository.Create(departure);
        }

        public Departure Delete(int id)
        {
            Departure departure = _departureRepository.Get(p => p.Id == id).FirstOrDefault();
            if (departure != null)
            {
                return _departureRepository.Delete(departure);
            }
            return null;
        }

        public Departure Update(Departure departure)
        {
            return _departureRepository.Update(departure);
        }

        public Departure Get(int id)
        {
            return _departureRepository.Get(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Departure> GetAll()
        {
            return _departureRepository.GetAll();
        }
    }
}
