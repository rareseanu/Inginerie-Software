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
    public class TrainService : ITrainService
    {
        private ITrainRepository _trainRepository;
        private IMapper _mapper;
        private IWagonRepository _wagonRepository;
        public TrainService(ITrainRepository trainRepository, IMapper mapper, IWagonRepository wagonRepository)
        {
            _trainRepository = trainRepository;
            _mapper = mapper;
            _wagonRepository = wagonRepository;
        }
        public async Task<Result<TrainDTO>> Add(TrainDTO trainDTO)
        {
            Train train = new Train();
            train.Number = trainDTO.Number;
            train = await _trainRepository.Create(train);
            for (int i = 0; i < trainDTO.WagonCount; i++)
            {
                await _wagonRepository.Create(new Wagon() { Number = i, NumberOfSeats = trainDTO.TotalNumberOfSeats / trainDTO.WagonCount,TrainId = train.Id });
            }
            return Result<TrainDTO>.Success(trainDTO);
        }
        public async Task<Train> Delete(int id)
        {
            Train train = await _trainRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (train != null)
            {
                return await _trainRepository.Delete(train);
            }
            return null;
        }
        public async Task<Result<TrainDTO>> Update(TrainDTO trainDTO)
        {
            Train train = new Train();
            train.Id = trainDTO.Id;
            train.Number = trainDTO.Number;
            train = await _trainRepository.Update(train);
            List<Wagon> wagons = await (await _wagonRepository.GetAll(p => p.TrainId == train.Id)).ToListAsync();
            if (wagons.Count() <= trainDTO.WagonCount)
            {
                await AddWagons(trainDTO, wagons);
            }
            else
            {
                await RemoveWagons(trainDTO, wagons);
            }
            return Result<TrainDTO>.Success(trainDTO);
        }

        private async Task AddWagons(TrainDTO trainDTO,List<Wagon> wagons)
        {
            for (int i = 0; i < wagons.Count(); i++)
            {
                await _wagonRepository.Update(new Wagon() { Id = wagons[i].Id, Number = i, NumberOfSeats = trainDTO.TotalNumberOfSeats / trainDTO.WagonCount, TrainId = trainDTO.Id });
            }
            for (int i = wagons.Count(); i < trainDTO.WagonCount; i++)
            {
                await _wagonRepository.Create(new Wagon() {Number = i, NumberOfSeats = trainDTO.TotalNumberOfSeats / trainDTO.WagonCount, TrainId = trainDTO.Id });
            }
        }
        private async Task RemoveWagons(TrainDTO trainDTO, List<Wagon> wagons)
        {
            for (int i = 0; i < trainDTO.WagonCount; i++)
            {
                await _wagonRepository.Update(new Wagon() { Id = wagons[i].Id, Number = i, NumberOfSeats = trainDTO.TotalNumberOfSeats / trainDTO.WagonCount, TrainId = trainDTO.Id });
            }
            for (int i = trainDTO.WagonCount; i < wagons.Count(); i++)
            {
                await _wagonRepository.Delete(wagons[i]);
            }
        }

        public async Task<Result<TrainDTO>> Get(int id)
        {
            Train train = await _trainRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            List<Wagon> wagons = await (await _wagonRepository.GetAll(p => p.TrainId == train.Id)).ToListAsync();
            TrainDTO trainDTO = new TrainDTO() { Id = train.Id, Number = train.Number, WagonCount=wagons.Count,TotalNumberOfSeats=wagons.Count*wagons[0].NumberOfSeats };
            return Result<TrainDTO>.Success(trainDTO);
        }
        public async Task<IEnumerable<TrainDTO>> GetAll()
        {
            List<Train> trains = await (await _trainRepository.GetAll()).ToListAsync();
            List<TrainDTO> trainDTOs = new List<TrainDTO>();
            foreach(Train train in trains) {
                List<Wagon> wagons = await (await _wagonRepository.GetAll(p => p.TrainId == train.Id)).ToListAsync();
                TrainDTO trainDTO = new TrainDTO() { Id = train.Id, Number = train.Number, WagonCount = wagons.Count, TotalNumberOfSeats = wagons.Count * wagons[0].NumberOfSeats };
                trainDTOs.Add(trainDTO);
            }
            return trainDTOs;
        }
    }
}
