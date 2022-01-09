using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("")]
        public async Task<ObjectResult> GetUsers()
        {
            return Ok(null);
        }
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetUser([FromRoute] int id)
        {
            return Ok(await _userService.Get(id));
        }
        [HttpPut("register")]
        public async Task<ObjectResult> Register([FromBody] LoginDTO loginDTO)
        {
            return Ok(await _userService.Register(loginDTO.Email, loginDTO.Password));
        }

        [HttpDelete("delete")]
        public async Task<ObjectResult> RemoveUser([FromRoute] Guid id)
        {
            return Ok(null);
        }
        [HttpPost("")]
        public async Task<ObjectResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            return Ok(await _userService.Update(userDTO));
        }
        [HttpPost("login")]
        public async Task<ObjectResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _userService.Login(loginDTO.Email, loginDTO.Password);
            if (result.Value == null)
            {
                return Ok(result);
            }
            SetRefreshTokenCookie(result.Value.RefreshToken, result.Value.ExpiresAt);
            return Ok(result);
        }

        [HttpPut("refreshToken")]
        public async Task<ObjectResult> RefreshToken()
        {
            if (Request.Cookies["refreshToken"] != null)
            {
                var result = await _userService.RefreshToken(Request.Cookies["refreshToken"]);
                if (result?.Value != null)
                {
                    SetRefreshTokenCookie(result.Value.RefreshToken, result.Value.ExpiresAt);
                }
                else
                {
                    await RevokeToken();
                }
                return Ok(result);
            }
            return Ok(null);
        }

        private void SetRefreshTokenCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = expires,
                SameSite = SameSiteMode.None
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

        [HttpPost("revokeToken")]
        public async Task<ObjectResult> RevokeToken()
        {
            await _userService.RevokeToken(Request.Cookies["refreshToken"]);
            if (Request.Cookies["refreshToken"] != null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.Now.AddDays(-1d),
                    SameSite = SameSiteMode.None
                };
                Response.Cookies.Append("refreshToken", "", cookieOptions);
            }

            return Ok(null);
        }
    }
}
