using Logix_Movie_Application.Dtos;

namespace Logix_Movie_Application.Interfaces
{
    public interface IUser
    {
        Task<UserRequest> AuthenticateUser(UserRequest user);

        Task<bool> Register(UserRequest user);

        Task<bool> IsUserExists(int userId);

        Task<bool> CheckEmailAvailability(string email);
    }
}
