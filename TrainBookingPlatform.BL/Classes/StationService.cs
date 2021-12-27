using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Classes
{
    public class StationService : IStationService
    {
        private IStationRepository _stationRepository;
        private IMapper _mapper;

        public StationService(IStationRepository stationRepository, IMapper mapper)
        {
            _stationRepository = stationRepository;
            _mapper = mapper;
        }

        public async Task<Station> Add(StationDTO stationDTO)
        {
            Station station = _mapper.Map<Station>(stationDTO);
            station.Id = 0;
            return await _stationRepository.Create(station);
        }

        public async Task<Station> Delete(int id)
        {
            Station station = await _stationRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (station != null)
            {
                return await _stationRepository.Delete(station);
            }
            return null;
        }

        public async Task<Station> Update(StationDTO stationDTO)
        {
            Station station = _mapper.Map<Station>(stationDTO);
            return await _stationRepository.Update(station);

        }

        public async Task<StationDTO> Get(int id)
        {
            return _mapper.Map<StationDTO>(await _stationRepository.Get(p => p.Id == id).FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<StationDTO>> GetAll()
        {
            List<Station> list = await (await _stationRepository.GetAll()).ToListAsync();
            List<StationDTO> listDTO = _mapper.Map<List<StationDTO>>(list);
            return listDTO;
        }
    }
}
