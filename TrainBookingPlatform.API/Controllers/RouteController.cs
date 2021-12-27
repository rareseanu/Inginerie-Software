using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/route")]
    public class RouteController : Controller
    {
        private IRouteService _service;

        public RouteController(IRouteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ObjectResult> AddRoute([FromBody] RouteDTO routeDTO)
        {    
            await _service.Add(routeDTO);
            return Ok("added");
        }
        [HttpPut]
        public async Task<ObjectResult> UpdateRoute([FromBody] RouteDTO routeDTO)
        {
            await _service.Update(routeDTO);
            return Ok("updated");
        }
        [HttpDelete("{id}")]
        public async Task<ObjectResult> RemoveRoute([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok("removed");
        }
        [HttpGet]
        public async Task<ObjectResult> GetRoutes()
        {
            return Ok(await _service.GetAll());
        }
        [NonAction]
        public async Task<ObjectResult> GetRoute([FromBody] Guid id)
        {
            return Ok(null);
        }
    }
}