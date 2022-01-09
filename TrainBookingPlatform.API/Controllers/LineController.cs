using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/line")]
    public class LineController : Controller
    {
        private ILineService _service;
        private IRouteService _routeService;

        public LineController(ILineService service, IRouteService routeService)
        {
            _service = service;
            _routeService = routeService;
        }

        [HttpPost]
        public async Task<ObjectResult> AddLine([FromBody] LineDTO lineDTO)
        {    
            await _service.Add(lineDTO);
            return Ok("added");
        }
        [HttpPut]
        public async Task<ObjectResult> UpdateLine([FromBody] LineDTO lineDTO)
        {
            await _service.Update(lineDTO);
            return Ok("updated");
        }
        [HttpDelete("{id}")]
        public async Task<ObjectResult> RemoveLine([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok("removed");
        }
        [HttpGet]
        public async Task<ObjectResult> GetLines()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("by-stations")]
        public async Task<ObjectResult> GetRoutes([FromQuery] int departureStationId, [FromQuery] int destinationStationId)
        {
            List<LineDTO> lines = (await _service.GetAll()).Where(p => p.DepartureStationId == departureStationId).ToList();
            List<RouteDTO> routes = new List<RouteDTO>();
            foreach(LineDTO line in lines)
            {
                List<LineDTO> lines2 = (await _service.GetAll()).Where(p => p.RouteId == line.RouteId).ToList();
                foreach(LineDTO line2 in lines2)
                {
                    if(line2.DestinationStationId == destinationStationId)
                    {
                        routes = routes.Concat((await _routeService.GetAll()).Where(p => p.Id == line.RouteId).ToList()).ToList();
                    }
                }
            }
            return Ok(routes.Distinct().ToList());
        }
    }
}