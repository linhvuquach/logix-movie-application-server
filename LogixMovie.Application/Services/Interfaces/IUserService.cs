using LogixMovie.Application.Dtos;

namespace LogixMovie.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateDto> AuthenticateAsync(UserDto user);

        Task<bool> RegisterAsync(UserDto user);
    }
}
