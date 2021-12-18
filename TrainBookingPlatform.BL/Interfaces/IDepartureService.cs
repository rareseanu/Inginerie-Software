using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IDepartureService
    {
        public Task<Departure> Add(Departure departure);
        public Task<Departure> Delete(int id);
        public Task<Departure> Update(Departure departure);
        public Departure Get(int id);
        public IEnumerable<Departure> GetAll();
    }
}
