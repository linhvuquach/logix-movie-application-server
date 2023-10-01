using LogixMovie.Domain.Entities;
using LogixMovie.Domain.Models;
using LogixMovie.Domain.Repositories;
using LogixMovie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LogixMovie.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MovieDBContext movieDBContext) : base(movieDBContext)
        {
        }

        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                await _movieDBContext.Users.AddAsync(user);
                await _movieDBContext.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                // Add handle exception here

                return false;
            }
        }

        public async Task<UserLikeOrDislikeMovie> GetListUserLikeOrDislikeMovieAsync(int userId)
        {
            var moviesLiked = await _movieDBContext.Movies
                .Where(m => m.UserActivities.Any(ua => ua.UserId == userId && ua.IsLiked))
                .Select(m => m.Id)
                .ToListAsync();

            var moviesDisliked = await _movieDBContext.Movies
                .Where(m => m.UserActivities.Any(ua => ua.UserId == userId && !ua.IsLiked))
                .Select(m => m.Id)
                .ToListAsync(); ;

            return new UserLikeOrDislikeMovie
            {
                UserId = userId,
                Likes = moviesLiked,
                Dislikes = moviesDisliked
            };
        }

        public async Task UserLikeOrDislikeMovieAsync(LikeOrDislikeMovie request)
        {
            var existingLike = await _movieDBContext.UserActivities
               .FirstOrDefaultAsync(ua => ua.MovieId == request.MovieId && ua.UserId == request.UserId);

            if (existingLike != null)
            {
                existingLike.IsLiked = request.IsLiked;
            }
            else
            {
                var newLike = new UserActivity
                {
                    MovieId = request.MovieId,
                    UserId = request.UserId,
                    IsLiked = request.IsLiked
                };
                _movieDBContext.UserActivities.Add(newLike);
            }

            await _movieDBContext.SaveChangesAsync();
        }
    }
}
