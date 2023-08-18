using Logix_Movie_Application.Models;

namespace Logix_Movie_Application.Dtos
{
    public class AuthenticateUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
