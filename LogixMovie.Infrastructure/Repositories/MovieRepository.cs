﻿using LogixMovie.Domain.Entities;
using LogixMovie.Domain.Repositories;
using LogixMovie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LogixMovie.Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {

        public MovieRepository(MovieDBContext movieDBContext) : base(movieDBContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            var result = await _movieDBContext.Movies
                .Include(m => m.UserActivities)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
    }
}
