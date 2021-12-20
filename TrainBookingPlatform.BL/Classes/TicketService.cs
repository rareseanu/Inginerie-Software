using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.BL.Classes
{
    public class TicketService : ITicketService
    {
        private ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<Ticket> Add(Ticket ticket)
        {
            return await _ticketRepository.Create(ticket);
        }
        public async Task<Ticket> Delete(int id)
        {
            Ticket ticket = await _ticketRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (ticket != null)
            {
                return await _ticketRepository.Delete(ticket);
            }
            return null;
        }
        public async Task<Ticket> Update(Ticket ticket)
        {
            return await _ticketRepository.Update(ticket);
        }

        public async Task<Ticket> Get(int id)
        {
            return await _ticketRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _ticketRepository.GetAll();
        }
    }
}
