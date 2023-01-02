using System.ComponentModel.DataAnnotations;
using VetClinic_backend.Models;

namespace VetClinic_backend.Dto.User
{
    public class UserRegisterDto
    {
        // Register user model dto
        [Required(ErrorMessage = "This value is required.")]
        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ]{3,24}")]
        [MaxLength(24)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This value is required.")]
        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ]{3,30}")]
        [MaxLength(30)]
        [MinLength(3)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This value is required.")]
        [RegularExpression(@"^[a-zA-Z0-9\.\-_]{1,}@[a-zA-Z0-9\-_]{1,}\.[a-zA-Z\.]{1,}$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This value is required.")]
        [RegularExpression(@"^[0-9]*$")]
        [MaxLength(9)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }

        public int Role { get; set;}
    }
}
