using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IRouteService
    {
        public Task<Route> Add(RouteDTO routeDTO);
        public Task<Route> Delete(int id);
        public Task<Route> Update(RouteDTO routeDTO);
        public Task<RouteDTO> Get(int id);
        public Task<IEnumerable<RouteDTO>> GetAll();
    }
}
