using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IRouteService
    {
        public Task<Result<RouteDTO>> Add(RouteDTO routeDTO);
        public Task<Route> Delete(int id);
        public Task<Result<RouteDTO>> Update(RouteDTO routeDTO);
        public Task<Result<RouteDTO>> Get(int id);
        public Task<IEnumerable<RouteDTO>> GetAll();
    }
}
