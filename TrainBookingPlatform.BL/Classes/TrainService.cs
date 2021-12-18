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
            Train train = _trainRepository.Get(p => p.Id == id).FirstOrDefault();
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

        public Train Get(int id)
        {
            return _trainRepository.Get(p => p.Id == id).FirstOrDefault();
        }
        public IEnumerable<Train> GetAll()
        {
            return _trainRepository.GetAll();
        }
    }
}
