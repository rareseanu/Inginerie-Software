using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/station")]
    public class StationController : Controller
    {
        [NonAction]
        public async Task<ObjectResult> AddStation([FromBody] StationDTO stationDTO)
        {
            return Ok(stationDTO);
        }
        [NonAction]
        public async Task<ObjectResult> UpdateStation([FromBody] StationDTO stationDTO)
        {
            return Ok(stationDTO);
        }
        [NonAction]
        public async Task<ObjectResult> RemoveStation([FromBody] StationDTO stationDTO)
        {
            return Ok(stationDTO);
        }
        [NonAction]
        public async Task<ObjectResult> GetStations()
        {
            return Ok(null);
        }
        [NonAction]
        public async Task<ObjectResult> GetStation([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
