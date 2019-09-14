using ChessBackend.Data.DataEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Data.Reposities
{
    public class UserRepository : IRepository<User>
    {
        private readonly ChessContext _chessContext;
        public UserRepository(ChessContext chessContext)
        {
            _chessContext = chessContext;
        }

        public async Task DeleteByIdAsync(string id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
                return;

            _chessContext.Users.Remove(user);
            await CommitAsync();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _chessContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _chessContext.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            var userToUpdate = await GetByIdAsync(user.Id);

            if (userToUpdate == null)
                return;

            _chessContext.Entry(userToUpdate).CurrentValues.SetValues(user);
        }

        private async Task CommitAsync()
        {
            await _chessContext.SaveChangesAsync();
        }
    }
}
