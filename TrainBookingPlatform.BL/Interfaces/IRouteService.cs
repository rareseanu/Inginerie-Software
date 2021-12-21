using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface IRouteService
    {
        public Task<Route> Add(Route route);
        public Task<Route> Delete(int id);
        public Task<Route> Update(Route route);
        public Task<Route> Get(int id);
        public Task<IEnumerable<Route>> GetAll();
    }
}
