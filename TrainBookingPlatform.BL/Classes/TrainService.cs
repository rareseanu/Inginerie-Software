using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.BL.Classes
{
    public class TrainService : ITrainService
    {
        private ITrainRepository _trainRepository;
        public TrainService(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }
        public async Task<Train> Add(Train train)
        {
            return await _trainRepository.Create(train);
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
        public async Task<Train> Update(Train train)
        {
            return await _trainRepository.Update(train);
        }

        public async Task<Train> Get(int id)
        {
            return await _trainRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Train>> GetAll()
        {
            return await _trainRepository.GetAll();
        }
    }
}
