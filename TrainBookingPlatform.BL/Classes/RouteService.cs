using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Classes
{
    public class RouteService : IRouteService
    {
        private IRouteRepository _routeRepository;
        private IMapper _mapper;

        public RouteService(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<Result<RouteDTO>> Add(RouteDTO routeDTO)
        {
            Route route = _mapper.Map<Route>(routeDTO);
            route.Id = 0;
            return Result<RouteDTO>.Success(_mapper.Map<RouteDTO>(await _routeRepository.Create(route)));
        }

        public async Task<Route> Delete(int id)
        {
            Route route = await _routeRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (route != null)
            {
                return await _routeRepository.Delete(route);
            }
            return null;
        }

        public async Task<Result<RouteDTO>> Update(RouteDTO routeDTO)
        {
            Route route = _mapper.Map<Route>(routeDTO);
            return Result<RouteDTO>.Success(_mapper.Map<RouteDTO>(await _routeRepository.Update(route)));
        }

        public async Task<Result<RouteDTO>> Get(int id)
        {
            Route route = await _routeRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (route != null)
            {
                return Result<RouteDTO>.Success(_mapper.Map<RouteDTO>(route));
            }
            return Result<RouteDTO>.Failure("Route not found.");
        }

        public async Task<IEnumerable<RouteDTO>> GetAll()
        {
            List<Route> list = await (await _routeRepository.GetAll()).ToListAsync();
            List<RouteDTO> listDTO = _mapper.Map<List<RouteDTO>>(list);
            return listDTO;
        }
    }
}
