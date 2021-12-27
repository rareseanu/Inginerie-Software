using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IStationService
    {
        public Task<Result<StationDTO>> Add(StationDTO stationDTO);
        public Task<Station> Delete(int id);
        public Task<Result<StationDTO>> Update(StationDTO stationDTO);
        public Task<Result<StationDTO>> Get(int id);
        public Task<IEnumerable<StationDTO>> GetAll();
    }
}
