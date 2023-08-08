using Logix_Movie_Application.Data;
using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Interfaces;
using Logix_Movie_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Logix_Movie_Application.Business
{
    public class UserActivityRepository : IUserActivity
    {
        private readonly MovieDBContext _movieDBContext;

        public UserActivityRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public async Task LikeOrDislikeMovie(LikeDislikeRequest request)
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
