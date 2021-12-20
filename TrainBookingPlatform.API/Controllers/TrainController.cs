using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/train")]
    public class TrainController : Controller
    {
        private ITrainService _service;

        public TrainController(ITrainService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ObjectResult> AddTrain([FromBody] Train train)
        {
            await _service.Add(train);
            return Ok("added");
        }
        [HttpPut]
        public async Task<ObjectResult> UpdateTrain([FromBody] Train train)
        {
            await _service.Update(train);
            return Ok("updated");
        }
        [HttpDelete("{id}")]
        public async Task<ObjectResult> RemoveTrain([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok("removed");
        }
        [HttpGet]
        public async Task<ObjectResult> GetTrains()
        {
            return Ok(_service.GetAll());
        }
        [NonAction]
        public async Task<ObjectResult> GetTrain([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
