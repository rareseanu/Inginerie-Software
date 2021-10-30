using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    public class DepartureController : Controller
    {
        public async Task<ObjectResult> AddDeparture([FromBody] DepartureDTO departureDTO)
        {
            return Ok(departureDTO);
        }

        public async Task<ObjectResult> UpdateDeparture([FromBody] DepartureDTO departureDTO)
        {
            return Ok(departureDTO);
        }

        public async Task<ObjectResult> RemoveDeparture([FromBody] DepartureDTO departureDTO)
        {
            return Ok(departureDTO);
        }

        public async Task<ObjectResult> GetDepartures()
        {
            return Ok(null);
        }

        public async Task<ObjectResult> GetDeparture([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
