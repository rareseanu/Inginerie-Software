using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Classes
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRefreshTokenRepository _refreshTokenRepository;

        public UserService(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<User> Add(User user)
        {
            return await _userRepository.Create(user);
        }
        public User Delete(int id)
        {
            User user = _userRepository.Get(p => p.Id == id).FirstOrDefault();
            if (user != null)
            {
                return _userRepository.Delete(user);
            }
            return null;
        }
        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public User Get(int id)
        {
            return _userRepository.Get(p => p.Id == id).FirstOrDefault();
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Task<LoginResponseDTO> Login(string email, string password)
        {
            using (SHA512 encryption = SHA512.Create())
            {
                password = Encoding.UTF8.GetString(encryption.ComputeHash(Encoding.UTF8.GetBytes(password)));
                User existingUser = _userRepository.Get(p => p.EmailAddress == email && p.Password == password).Include(p => p.Role).FirstOrDefault();
                if(existingUser != null)
                {
                    RefreshToken refreshToken = new RefreshToken()
                    {
                        Token = GenerateToken(),
                        ExpiresAt = DateTime.Now.AddDays(7),
                        UserId = existingUser.Id
                    };

                    await _refreshTokenRepository.Create(refreshToken);

                    return new LoginResponseDTO()
                    {
                        RefreshToken = refreshToken.Token,
                        Token = GenerateJwtToken(existingUser),
                        UserId = existingUser.Id,
                        ExpiresAt = refreshToken.ExpiresAt
                    };
                }
                return null;
            }
        }

        public async Task<LoginResponseDTO> RefreshToken(string refreshToken)
        {
            RefreshToken existingRefreshToken =  _refreshTokenRepository.Get(p => p.Token.Equals(refreshToken)).FirstOrDefault();

            if(existingRefreshToken != null)
            {
                User user = _userRepository.Get(p => p.Id == existingRefreshToken.UserId).Include(p => p.Role).FirstOrDefault();
                RefreshToken newRefreshToken = new RefreshToken()
                {
                    Token = GenerateToken(),
                    ExpiresAt = DateTime.Now.AddDays(7),
                    UserId = existingRefreshToken.UserId
                };

                _refreshTokenRepository.Delete(existingRefreshToken);
                await _refreshTokenRepository.Create(newRefreshToken);

                return new LoginResponseDTO()
                {
                    RefreshToken = newRefreshToken.Token,
                    Token = GenerateJwtToken(user),
                    UserId = user.Id,
                    ExpiresAt = newRefreshToken.ExpiresAt
                };
            }
            return null;
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSecret = Encoding.ASCII.GetBytes("asfasfasfasg1224124124124124safasfasfasfasf");
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.EmailAddress),
                    new Claim("Roles", user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddSeconds(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecret),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(jwtTokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }

        private string GenerateToken()
        {
            var randomBytes = new byte[32];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

        public async Task<User> Register(string email, string password)
        {
            using (SHA512 encryption = SHA512.Create()) { 
                User user = new User() { EmailAddress = email, Password = Encoding.UTF8.GetString(encryption.ComputeHash(Encoding.UTF8.GetBytes(password))),RoleId=1};
                User existingUser = _userRepository.Get(p => p.EmailAddress == email).FirstOrDefault();
                if (existingUser == null)
                {
                    user = await Add(user);
                    return user;
                }
                return null;
            }
        }
        
    }
}
