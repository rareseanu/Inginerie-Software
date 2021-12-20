using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.BL.Classes
{
    public class RouteService : IRouteService
    {
        private IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<Route> Add(Route route)
        {
            route.Id = 0;
            return await _routeRepository.Create(route);
        }

        public async Task<Route> Delete(int id)
        {
            Route route = _routeRepository.Get(p => p.Id == id).FirstOrDefault();
            if (route != null)
            {
                return await _routeRepository.Delete(route);
            }
            return null;
        }

        public async Task<Route> Update(Route route)
        {
            return await _routeRepository.Update(route);

        }

        public Route Get(int id)
        {
            return _routeRepository.Get(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Route> GetAll()
        {
            return _routeRepository.GetAll();
        }
    }
}