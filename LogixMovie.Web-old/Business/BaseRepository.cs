using Logix_Movie_Application.Data;
using Logix_Movie_Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logix_Movie_Application.Business
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
