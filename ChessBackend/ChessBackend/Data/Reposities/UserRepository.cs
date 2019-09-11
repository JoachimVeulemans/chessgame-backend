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
        public async Task<IList<User>> GetAll()
        {
            return await _chessContext.Users.ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _chessContext.Users.FindAsync(id);
        }
    }
}
