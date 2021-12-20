using Microsoft.EntityFrameworkCore;
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

        public async Task<Departure> Delete(int id)
        {
            Departure departure = await _departureRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (departure != null)
            {
                return await _departureRepository.Delete(departure);
            }
            return null;
        }

        public async Task<Departure> Update(Departure departure)
        {
            return await _departureRepository.Update(departure);
        }

        public async Task<Departure> Get(int id)
        {
            return await _departureRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Departure>> GetAll()
        {
            return await _departureRepository.GetAll();
        }
    }
}
