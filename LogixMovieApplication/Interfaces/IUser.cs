using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Models;

namespace Logix_Movie_Application.Interfaces
{
    public interface IUser : IBaseRepository<User>
    {
        Task<AuthenticateUser> Authenticate(UserRequest user);

        Task<bool> Register(UserRequest user);

        Task<bool> CheckEmailAvailability(string email);
    }
}
