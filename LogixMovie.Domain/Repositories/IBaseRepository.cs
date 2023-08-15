using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(int id);
    }
}
