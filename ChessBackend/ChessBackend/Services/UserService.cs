using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessBackend.Data.DataEntities;
using ChessBackend.Data.Reposities;
using ChessBackend.Entities.Models;

namespace ChessBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task DeleteAsync(string id)
        {
            await _userRepository.DeleteByIdAsync(id);
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
    }
}
