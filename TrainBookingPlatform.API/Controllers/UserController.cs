using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ObjectResult> GetUsers()
        {
            return Ok(null);
        }
        [HttpGet]
        public async Task<ObjectResult> GetUser([FromRoute] Guid id)
        {
            return Ok(null);
        }
        [HttpPut]
        public async Task<ObjectResult> Register([FromBody] UserDTO userDTO)
        {      
            return Ok(_userService.Register(userDTO.EmailAddress,userDTO.Password));
        }
        
        [HttpDelete]
        public async Task<ObjectResult> RemoveUser([FromRoute] Guid id)
        {
            return Ok(null);
        }
        [HttpPost]
        public async Task<ObjectResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            return Ok(null);
        }
        [HttpPost]
        public async Task<ObjectResult> Login([FromBody] LoginDTO loginDTO)
        {
            return Ok(_userService.Login(loginDTO.Email, loginDTO.Password));
        }

        [HttpPut]
        public async Task<ObjectResult> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            return Ok(null);
        }

        [HttpPost]
        public async Task<ObjectResult> RevokeToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            return Ok(null);
        }
    }
}
