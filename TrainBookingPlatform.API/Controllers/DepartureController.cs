using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/departure")]
    public class DepartureController : Controller
    {
        [NonAction]
        public async Task<ObjectResult> AddDeparture([FromBody] DepartureDTO departureDTO)
        {
            return Ok(departureDTO);
        }
        [NonAction]
        public async Task<ObjectResult> UpdateDeparture([FromBody] DepartureDTO departureDTO)
        {
            return Ok(departureDTO);
        }
        [NonAction]
        public async Task<ObjectResult> RemoveDeparture([FromBody] DepartureDTO departureDTO)
        {
            return Ok(departureDTO);
        }
        [NonAction]
        public async Task<ObjectResult> GetDepartures()
        {
            return Ok(null);
        }
        [NonAction]
        public async Task<ObjectResult> GetDeparture([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
