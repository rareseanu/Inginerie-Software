using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Classes
{
    public class TicketService : ITicketService
    {
        private ITicketRepository _ticketRepository;
        private IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
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

        public async Task<List<TicketDTO>> GetUserTickets(int userId)
        {
            List<Ticket> tickets = (await _ticketRepository.GetAll())
                .Include(p => p.Departure)
                .Include(p => p.Departure.Line)
                .Include(p => p.Departure.Line.DestinationStation)
                .Include(p => p.Departure.Line.DepartureStation)
                .Where(p => p.UserId == userId)
                .ToList();

            List<TicketDTO> ticketDTOs = new List<TicketDTO>();
            foreach (var ticket in tickets)
            {
                TicketDTO ticketDTO = _mapper.Map<TicketDTO>(ticket);
                ticketDTO.DepartureStationName = ticket.Departure.Line.DepartureStation.Name;
                ticketDTO.DestinationStationName = ticket.Departure.Line.DestinationStation.Name;

                ticketDTO.Departure = null;
                ticketDTOs.Add(ticketDTO);
            }

            return ticketDTOs;
        }
    }
}
