using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/station")]
    public class StationController : Controller
    {
        private IStationService _service;

        public StationController(IStationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ObjectResult> AddStation([FromBody] StationDTO stationDTO)
        {
            await _service.Add(stationDTO);
            return Ok("added");
        }
        [HttpPut]
        public async Task<ObjectResult> UpdateStation([FromBody] StationDTO stationDTO)
        {
            await _service.Update(stationDTO);
            return Ok("updated");
        }
        [HttpDelete("{id}")]
        public async Task<ObjectResult> RemoveStation([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok("removed");
        }
        [HttpGet]
        public async Task<ObjectResult> GetStations()
        {
            return Ok(await _service.GetAll());
        }
        [NonAction]
        public async Task<ObjectResult> GetStation([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
