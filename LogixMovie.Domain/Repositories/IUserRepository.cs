using LogixMovie.Domain.Entities;

namespace LogixMovie.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> AddUserAsync(User user);

        Task<bool> CheckEmailAvailabilityAsync(string email);
    }
}
