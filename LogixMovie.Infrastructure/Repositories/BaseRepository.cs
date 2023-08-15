using LogixMovie.Domain.Repositories;
using LogixMovie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LogixMovie.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MovieDBContext _movieDBContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
            _dbSet = _movieDBContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }
    }
}
