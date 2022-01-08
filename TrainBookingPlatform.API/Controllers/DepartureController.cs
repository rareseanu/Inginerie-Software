using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/departure")]
    public class DepartureController : Controller
    {
        private IDepartureService _service;

        public DepartureController(IDepartureService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ObjectResult> AddDeparture([FromBody] DepartureDTO departureDTO)
        {
            await _service.Add(departureDTO);
            return Ok("added");
        }
        [HttpPut]
        public async Task<ObjectResult> UpdateDeparture([FromBody] DepartureDTO departureDTO)
        {
            await _service.Update(departureDTO);
            return Ok("updated");
        }
        [HttpDelete("{id}")]
        public async Task<ObjectResult> RemoveDeparture([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok("removed");
        }
        [HttpGet]
        public async Task<ObjectResult> GetDepartures()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("by-route/{routeId}")]
        public async Task<ObjectResult> GetDepartures([FromRoute] int routeId)
        {
            return Ok((await _service.GetAll()).Where(p => p.RouteId == routeId));
        }
        [NonAction]
        public async Task<ObjectResult> GetDeparture([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
