using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    public class TicketController : Controller
    {
        public async Task<ObjectResult> AddTicket([FromBody] TicketDTO ticketDTO)
        {
            return Ok(ticketDTO);
        }
        public async Task<ObjectResult> UpdateTicket([FromBody] TicketDTO ticketDTO)
        {
            return Ok(ticketDTO);
        }
        public async Task<ObjectResult> RemoveTicket([FromRoute] Guid id)
        {
            return Ok(null);
        }
        public async Task<ObjectResult> GetTickets()
        {
            return Ok(null);
        }
        public async Task<ObjectResult> GetTicket([FromRoute] Guid id)
        {
            return Ok(null);
        }
    }
}
