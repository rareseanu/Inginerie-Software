using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Classes
{
    public class WagonService : IWagonService
    {
        private IWagonRepository _wagonRepository;
        private IMapper _mapper;

        public WagonService(IWagonRepository wagonRepository, IMapper mapper)
        {
            _wagonRepository = wagonRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<WagonDTO>> GetAllByTrainId(int trainID)
        {
            List<Wagon> wagons = await(await _wagonRepository.GetAll(p => p.TrainId == trainID)).ToListAsync();
            return _mapper.Map<List<WagonDTO>>(wagons);
        }
    }
}
