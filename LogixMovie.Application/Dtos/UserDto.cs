using System.ComponentModel.DataAnnotations;

namespace LogixMovie.Application.Dtos
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
