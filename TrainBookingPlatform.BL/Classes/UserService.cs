using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.BL.Classes
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        public User Login(string email, string password)
        {
            using (SHA512 encryption = SHA512.Create())
            {
                password = encryption.ComputeHash(Encoding.UTF8.GetBytes(password)).ToString();
                User existingUser = _userRepository.Get(p => p.EmailAddress == email && p.Password == password).FirstOrDefault();
                if(existingUser != null)
                {
                    return existingUser;
                }
                return null;
            }
        }

        public async Task<User> Register(string email, string password)
        {
            using (SHA512 encryption = SHA512.Create()) { 
                User user = new User() { EmailAddress = email, Password = encryption.ComputeHash(Encoding.UTF8.GetBytes(password)).ToString() };
                User existingUser = _userRepository.Get(p => p.EmailAddress == email).FirstOrDefault();
                if (existingUser == null)
                {
                    await Add(user);
                    return user;
                }
                return null;
            }
        }
        
    }
}
