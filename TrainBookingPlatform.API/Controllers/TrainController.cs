using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    public class TrainController : Controller
    {
        public async Task<ObjectResult> AddTrain([FromBody] TrainDTO trainDTO)
        {
            return Ok(trainDTO);
        }
        public async Task<ObjectResult> UpdateTrain([FromBody] TrainDTO trainDTO)
        {
            return Ok(trainDTOs);
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
