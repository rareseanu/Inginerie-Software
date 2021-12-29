using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/wagon")]
    public class WagonController : Controller
    {
        private IWagonService _service;
        public WagonController(IWagonService wagonService)
        {
            _service = wagonService;
        }

        [HttpGet("by-train/{trainID}")]
        public async Task<ObjectResult> GetWagons([FromRoute] int trainID)
        {
            return Ok(await _service.GetAllByTrainId(trainID));
        }
    }
}
