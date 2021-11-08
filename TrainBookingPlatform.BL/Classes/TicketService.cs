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
        public Ticket Delete(int id)
        {
            Ticket ticket = _ticketRepository.Get(p => p.Id == id).FirstOrDefault();
            if (ticket != null)
            {
                return _ticketRepository.Delete(ticket);
            }
            return null;
        }
        public Ticket Update(Ticket ticket)
        {
            return _ticketRepository.Update(ticket);
        }

        public Ticket Get(int id)
        {
            return _ticketRepository.Get(p => p.Id == id).FirstOrDefault();
        }
        public IEnumerable<Ticket> GetAll()
        {
            return _ticketRepository.GetAll();
        }
    }
}
