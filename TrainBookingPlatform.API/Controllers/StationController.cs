using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    public class StationController : Controller
    {
        public async Task<ObjectResult> AddStation([FromBody] StationDTO stationDTO)
        {
            return Ok(stationDTO);
        }

        public async Task<ObjectResult> UpdateStation([FromBody] StationDTO stationDTO)
        {
            return Ok(stationDTO);
        }

        public async Task<ObjectResult> RemoveStation([FromBody] StationDTO stationDTO)
        {
            return Ok(stationDTO);
        }

        public async Task<ObjectResult> GetStations()
        {
            return Ok(null);
        }

        public async Task<ObjectResult> GetStation([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
