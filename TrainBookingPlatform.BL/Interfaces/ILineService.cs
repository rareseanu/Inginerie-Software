using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface ILineService
    {
        public Task<Result<LineDTO>> Add(LineDTO lineDTO);
        public Task<Line> Delete(int id);
        public Task<Result<LineDTO>> Update(LineDTO lineDTO);
        public Task<Result<LineDTO>> Get(int id);
        public Task<IEnumerable<LineDTO>> GetAll();
    }
}
