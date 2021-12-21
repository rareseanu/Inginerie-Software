using Microsoft.EntityFrameworkCore;
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
            if (route.DepartureStationId != route.DestinationStationId)
            {
                return await _routeRepository.Create(route);
            }
            return null;
        }

        public async Task<Route> Delete(int id)
        {
            Route route = await _routeRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (route != null)
            {
                return await _routeRepository.Delete(route);
            }
            return null;
        }

        public async Task<Route> Update(Route route)
        {
            if (route.DepartureStationId != route.DestinationStationId)
            {
                return await _routeRepository.Update(route);
            }
            return null;
        }

        public async Task<Route> Get(int id)
        {
            return await _routeRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Route>> GetAll()
        {
            IQueryable<Route> list = await _routeRepository.GetAll();
            return list;
        }
    }
}