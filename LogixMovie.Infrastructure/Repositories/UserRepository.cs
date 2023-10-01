using LogixMovie.Domain.Entities;
using LogixMovie.Domain.Repositories;
using LogixMovie.Infrastructure.Data;

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
    }
}
