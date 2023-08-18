using LogixMovie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Domain.Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
    }
}
