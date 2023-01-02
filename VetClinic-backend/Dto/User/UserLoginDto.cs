using System.ComponentModel.DataAnnotations;

namespace VetClinic_backend.Dto.User
{
    public class UserLoginDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
