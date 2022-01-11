using AutoMapper;
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
using TrainBookingPlatform.TL;
using TrainBookingPlatform.TL.DTOs;

namespace TrainBookingPlatform.BL.Classes
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRefreshTokenRepository _refreshTokenRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
        }
        public async Task<Result<UserDTO>> Add(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            User createdUser = await _userRepository.Create(user);
            return Result<UserDTO>.Success(_mapper.Map<UserDTO>(createdUser));
        }
        public async Task<User> Delete(int id)
        {
            User user = await _userRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                return await _userRepository.Delete(user);
            }
            return null;
        }
        public async Task<Result<UserDTO>> Update(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            using (SHA512 encryption = SHA512.Create())
            {
                user.Password = Encoding.UTF8.GetString(encryption.ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
                User existingUser = await _userRepository.Get(p => p.Id == user.Id).FirstOrDefaultAsync();
                try
                {
                    if (userDTO.NewPassword == "")
                    {
                        user.Password = existingUser.Password;
                    }
                    if (userDTO.NewPassword != "" && existingUser.Password == user.Password)
                    {
                        user.Password = Encoding.UTF8.GetString(encryption.ComputeHash(Encoding.UTF8.GetBytes(userDTO.NewPassword)));
                    }
                    else if (userDTO.NewPassword != "" && existingUser.Password != user.Password)
                    {
                        return Result<UserDTO>.Failure("User update failed.");
                    }
                    await _userRepository.Update(user);
                    return Result<UserDTO>.Success(userDTO);
                }
                catch (Exception ex)
                {
                    return Result<UserDTO>.Failure("User update failed.");
                }
            }
            return Result<UserDTO>.Failure("User update failed.");
        }

        public async Task<Result<UserDTO>> Get(int id)
        {
            var user = await _userRepository.Get(p => p.Id == id).FirstOrDefaultAsync();
            user.Password = null;
            if (user == null)
            {
                return Result<UserDTO>.Failure("User not found.");
            }
            return Result<UserDTO>.Success(_mapper.Map<UserDTO>(user));
        }
        public async Task<Result<IEnumerable<UserDTO>>> GetAll()
        {
            List<User> users = await (await _userRepository.GetAll()).ToListAsync();
            return Result<IEnumerable<UserDTO>>.Success(_mapper.Map<List<UserDTO>>(users));
        }

        public async Task<Result<LoginResponseDTO>> Login(string email, string password)
        {
            using (SHA512 encryption = SHA512.Create())
            {
                password = Encoding.UTF8.GetString(encryption.ComputeHash(Encoding.UTF8.GetBytes(password)));
                User existingUser = await _userRepository.Get(p => p.EmailAddress == email && p.Password == password).Include(p => p.Role).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    RefreshToken refreshToken = new RefreshToken()
                    {
                        Token = GenerateToken(),
                        ExpiresAt = DateTime.Now.AddDays(7),
                        UserId = existingUser.Id
                    };

                    await _refreshTokenRepository.Create(refreshToken);

                    var response = new LoginResponseDTO()
                    {
                        RefreshToken = refreshToken.Token,
                        Token = GenerateJwtToken(existingUser),
                        UserId = existingUser.Id,
                        ExpiresAt = refreshToken.ExpiresAt
                    };
                    return Result<LoginResponseDTO>.Success(response);
                }
                return Result<LoginResponseDTO>.Failure("Invalid user credentials.");
            }
        }

        public async Task<Result<LoginResponseDTO>> RefreshToken(string refreshToken)
        {
            RefreshToken existingRefreshToken = await _refreshTokenRepository.Get(p => p.Token.Equals(refreshToken)).FirstOrDefaultAsync();

            if (existingRefreshToken != null)
            {
                User user = await _userRepository.Get(p => p.Id == existingRefreshToken.UserId).Include(p => p.Role).FirstOrDefaultAsync();
                RefreshToken newRefreshToken = new RefreshToken()
                {
                    Token = GenerateToken(),
                    ExpiresAt = DateTime.Now.AddDays(7),
                    UserId = existingRefreshToken.UserId
                };

                await _refreshTokenRepository.Delete(existingRefreshToken);
                await _refreshTokenRepository.Create(newRefreshToken);

                var result = new LoginResponseDTO()
                {
                    RefreshToken = newRefreshToken.Token,
                    Token = GenerateJwtToken(user),
                    UserId = user.Id,
                    ExpiresAt = newRefreshToken.ExpiresAt
                };

                return Result<LoginResponseDTO>.Success(result);
            }
            return Result<LoginResponseDTO>.Failure("Expired user session.");
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
                    new Claim("Roles", user.Role.Name),
                    new Claim("RoleId", user.RoleId.ToString())
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

        public async Task<Result<UserDTO>> Register(string email, string password)
        {
            using (SHA512 encryption = SHA512.Create())
            {
                UserDTO user = new UserDTO() { EmailAddress = email, OldPassword = Encoding.UTF8.GetString(encryption.ComputeHash(Encoding.UTF8.GetBytes(password))), RoleId = 2 };
                User existingUser = await _userRepository.Get(p => p.EmailAddress == email).FirstOrDefaultAsync();
                if (existingUser == null)
                {
                    return await Add(user);
                }
                return Result<UserDTO>.Failure("User already exists.");
            }
        }

        public async Task RevokeToken(string token)
        {
            var refreshToken = await _refreshTokenRepository.Get(p => p.Token.Equals(token)).FirstOrDefaultAsync();

            if (refreshToken != null)
            {
                await _refreshTokenRepository.Delete(refreshToken);
            }
        }

    }
}
