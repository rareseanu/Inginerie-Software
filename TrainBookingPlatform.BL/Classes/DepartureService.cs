using System;
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
    public class DepartureService : IDepartureService
    {
        private IDepartureRepository _departureRepository;
        private IMapper _mapper;

        public DepartureService(IDepartureRepository departureRepository, IMapper mapper)
        {
            _departureRepository = departureRepository;
            _mapper = mapper;
        }

        public async Task<Departure> Add(DepartureDTO departureDTO)
        {
            var departure = _mapper.Map<Departure>(departureDTO);
            departure.Line = null;
            return await _departureRepository.Create(departure);
        }

        public async Task<Departure> Delete(int id)
        {
            Departure departure = await _departureRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (departure != null)
            {
                return await _departureRepository.Delete(departure);
            }
            return null;
        }

        public async Task<Departure> Update(DepartureDTO departureDTO)
        {
            var departure = _mapper.Map<Departure>(departureDTO);
            departure.Line = null;
            return await _departureRepository.Update(departure);
        }

        public async Task<Departure> Get(int id)
        {
            return await _departureRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DepartureDTO>> GetAll()
        {
            List<DepartureDTO> departures = new List<DepartureDTO>();
            foreach(var departure in (await _departureRepository.GetAll()).Include(p => p.Line).Include(p => p.Line.DestinationStation).Include(p => p.Line.DepartureStation))
            {
                var departureDTO = _mapper.Map<DepartureDTO>(departure);
                departureDTO.Line.DestinationStationName = departure.Line.DestinationStation.Name;
                departureDTO.Line.DepartureStationName = departure.Line.DepartureStation.Name;
                departures.Add(departureDTO);
            }
            return departures;
        }
    }
}
