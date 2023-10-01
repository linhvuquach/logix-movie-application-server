using System.Linq.Expressions;
using LogixMovie.Domain.Repositories;
using LogixMovie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LogixMovie.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MovieDBContext _movieDBContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext ?? throw new ArgumentNullException(nameof(movieDBContext));
            _dbSet = _movieDBContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }
    }
}
