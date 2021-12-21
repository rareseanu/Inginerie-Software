using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : Controller
    {
        private ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ObjectResult> AddTicket([FromBody] Ticket ticket)
        {
            await _service.Add(ticket);
            return Ok("added");
        }
        [HttpPut]
        public async Task<ObjectResult> UpdateTicket([FromBody] Ticket ticket)
        {
            await _service.Update(ticket);
            return Ok("updated");
        }
        [HttpDelete("{id}")]
        public async Task<ObjectResult> RemoveTicket([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok("removed");
        }
        [HttpGet]
        public async Task<ObjectResult> GetTickets()
        {
            return Ok(await _service.GetAll());
        }
        [NonAction]
        public async Task<ObjectResult> GetTicket([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}
