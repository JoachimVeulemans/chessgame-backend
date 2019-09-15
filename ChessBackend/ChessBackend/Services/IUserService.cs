using ChessBackend.Data.DataEntities;
using ChessBackend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        
        Task DeleteAsync(string id);
        Task UpdateAsync(User updateUserModel);
    }
}
