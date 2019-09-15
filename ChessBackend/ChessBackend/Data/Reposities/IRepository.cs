using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Data.Reposities
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task DeleteByIdAsync(string id);
        Task UpdateAsync(T user);
    }
}
