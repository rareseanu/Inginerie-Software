using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : Controller
    {
        private ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [NonAction]
        public async Task<ObjectResult> AddTicket([FromBody] TicketDTO ticketDTO)
        {
            return Ok(ticketDTO);
        }
        [NonAction]
        public async Task<ObjectResult> UpdateTicket([FromBody] TicketDTO ticketDTO)
        {
            return Ok(ticketDTO);
        }
        [NonAction]
        public async Task<ObjectResult> RemoveTicket([FromRoute] Guid id)
        {
            return Ok(null);
        }
        [NonAction]
        public async Task<ObjectResult> GetTickets()
        {
            return Ok(null);
        }
        [NonAction]
        public async Task<ObjectResult> GetTicket([FromRoute] Guid id)
        {
            return Ok(null);
        }
    }
}
