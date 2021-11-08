using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    public class TrainController : Controller
    {
        private ITrainService _trainService;
        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }
        public async Task<ObjectResult> AddTrain([FromBody] TrainDTO trainDTO)
        {
            return Ok(trainDTO);
        }
        public async Task<ObjectResult> UpdateTrain([FromBody] TrainDTO trainDTO)
        {
            return Ok(trainDTO);
        }
        public async Task<ObjectResult> RemoveTrain([FromRoute] Guid id)
        {
            return Ok(null);
        }
        public async Task<ObjectResult> GetTrains()
        {
            return Ok(null);
        }
        public async Task<ObjectResult> GetTrain([FromRoute] Guid id)
        {
            return Ok(null);
        }
    }
}
