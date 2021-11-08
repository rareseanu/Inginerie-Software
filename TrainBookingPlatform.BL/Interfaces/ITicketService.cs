using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.BL.Interfaces
{
    public interface ITicketService
    {
        public Task<Ticket> Add(Ticket ticket);
        public Ticket Delete(int id);
        public Ticket Update(Ticket ticket);
        public Ticket Get(int id);
        public IEnumerable<Ticket> GetAll();
    }
}
