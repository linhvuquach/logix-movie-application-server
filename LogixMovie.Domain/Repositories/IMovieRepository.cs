using LogixMovie.Domain.Entities;

namespace LogixMovie.Domain.Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
    }
}
