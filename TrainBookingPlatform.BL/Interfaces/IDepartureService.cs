using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IDepartureService
    {
        public Task<Departure> Add(DepartureDTO departureDTO);
        public Task<Departure> Delete(int id);
        public Task<Departure> Update(DepartureDTO departureDTO);
        public Task<Departure> Get(int id);
        public Task<IEnumerable<DepartureDTO>> GetAll();
    }
}
