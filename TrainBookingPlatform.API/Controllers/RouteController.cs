using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    public class RouteController : Controller
    {
        public async Task<ObjectResult> AddRoute([FromBody] RouteDTO routeDTO)
        {
            return Ok(routeDTO);
        }

        public async Task<ObjectResult> UpdateRoute([FromBody] RouteDTO routeDTO)
        {
            return Ok(routeDTO);
        }

        public async Task<ObjectResult> RemoveRoute([FromBody] RouteDTO routeDTO)
        {
            return Ok(routeDTO);
        }

        public async Task<ObjectResult> GetRoutes()
        {
            return Ok(null);
        }

        public async Task<ObjectResult> GetRoutes([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
