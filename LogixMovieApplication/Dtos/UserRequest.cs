using System.ComponentModel.DataAnnotations;

namespace Logix_Movie_Application.Dtos
{
    public class UserRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
