using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Classes
{
    public class LineService : ILineService
    {
        private ILineRepository _lineRepository;
        private IMapper _mapper;

        public LineService(ILineRepository lineRepository, IMapper mapper)
        {
            _lineRepository = lineRepository;
            _mapper = mapper;
        }

        public async Task<Result<LineDTO>> Add(LineDTO lineDTO)
        {
            Line line = _mapper.Map<Line>(lineDTO);
            line.Id = 0;
            if (lineDTO.DepartureStationId != lineDTO.DestinationStationId)
            {
                return Result<LineDTO>.Success(_mapper.Map<LineDTO>(await _lineRepository.Create(line)));
            }
            return Result<LineDTO>.Failure("Failed to add the route.");
        }

        public async Task<Line> Delete(int id)
        {
            Line line = await _lineRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (line != null)
            {
                return await _lineRepository.Delete(line);
            }
            return null;
        }

        public async Task<Result<LineDTO>> Update(LineDTO lineDTO)
        {
            Line line = _mapper.Map<Line>(lineDTO);
            if (line.DepartureStationId != line.DestinationStationId)
            {
                return Result<LineDTO>.Success(_mapper.Map<LineDTO>(await _lineRepository.Update(line)));
            }
            return Result<LineDTO>.Failure("Failed to update the route.");
        }

        public async Task<Result<LineDTO>> Get(int id)
        {
            Line line = await _lineRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if(line != null)
            {
                return Result<LineDTO>.Success(_mapper.Map<LineDTO>(line));
            }
            return Result<LineDTO>.Failure("Route not found.");
        }

        public async Task<IEnumerable<LineDTO>> GetAll()
        {
            List<LineDTO> lines = new List<LineDTO>();
            foreach (var departure in (await _lineRepository.GetAll()).Include(p => p.DestinationStation).Include(p => p.DepartureStation))
            {
                var departureDTO = _mapper.Map<LineDTO>(departure);
                departureDTO.DestinationStationName = departure.DestinationStation.Name;
                departureDTO.DepartureStationName = departure.DepartureStation.Name;
                departureDTO.DepartureStation = null;
                departureDTO.DestinationStation = null;
                lines.Add(departureDTO);
            }
            return lines;
        }
    }
}