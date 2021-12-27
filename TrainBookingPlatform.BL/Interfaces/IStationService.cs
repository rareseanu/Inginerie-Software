using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IStationService
    {
        public Task<Station> Add(StationDTO stationDTO);
        public Task<Station> Delete(int id);
        public Task<Station> Update(StationDTO stationDTO);
        public Task<StationDTO> Get(int id);
        public Task<IEnumerable<StationDTO>> GetAll();
    }
}
