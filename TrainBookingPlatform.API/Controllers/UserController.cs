using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.API.Controllers
{
    public class UserController : Controller
    {
        public async Task<ObjectResult> GetUsers()
        {
            return Ok(null);
        }

        public async Task<ObjectResult> GetUser([FromRoute] Guid id)
        {
            return Ok(null);
        }

        public async Task<ObjectResult> AddUser([FromBody] UserDTO userDTO)
        {
            return Ok(null);
        }

        public async Task<ObjectResult> RemoveUser([FromRoute] Guid id)
        {
            return Ok(null);
        }

        public async Task<ObjectResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            return Ok(null);
        }

        public async Task<ObjectResult> Login([FromBody] LoginDTO loginDTO)
        {
            return Ok(null);
        }

        public async Task<ObjectResult> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            return Ok(null);
        }

        public async Task<ObjectResult> RevokeToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            return Ok(null);
        }
    }
}
