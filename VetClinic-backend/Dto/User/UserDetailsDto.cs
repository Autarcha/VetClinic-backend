using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using VetClinic_backend.Models;

namespace VetClinic_backend.Dto.User
{
    public class UserDetailsDto
    {
        [RegularExpression(@"^[a-zA-Z0-9\.\-_]{1,}@[a-zA-Z0-9\-_]{1,}\.[a-zA-Z\.]{1,}$")]
        public string? Email { get; set; }

        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ]{3,60}")]
        public string? Name { get; set; }

        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ]{3,60}$")]
        public string? Surname { get; set; }

        [RegularExpression(@"^[0-9]{9,9}$")]
        public string? PhoneNumber { get; set; }

        public int? Role { get; set; }

    }
}
