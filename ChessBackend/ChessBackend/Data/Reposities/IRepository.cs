using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Data.Reposities
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(string id);
    }
}
