using Logix_Movie_Application.Data;
using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logix_Movie_Application.Business
{
    public class UserRepository : IUser
    {
        private readonly MovieDBContext _movieDBContext;

        public UserRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public async Task<bool> Register(UserRequest user)
        {
            bool isEmailAvailable = await CheckEmailAvailability(user.Email);
            if (isEmailAvailable)
            {
                // TODO:
                // Hash password
                await _movieDBContext.Users.AddAsync(new Models.User
                {
                    Email = user.Email,
                    Password= user.Password,
                });
                await _movieDBContext.SaveChangesAsync();

                return true;
            }else
            {
                return false;
            }
        }

        public Task<UserRequest> AuthenticateUser(UserRequest user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExists(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckEmailAvailability(string email)
        {
            var result = await _movieDBContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return result == null;
        }
    }
}
