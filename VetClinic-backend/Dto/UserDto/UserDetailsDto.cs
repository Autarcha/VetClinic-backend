using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using VetClinic_backend.Models;

namespace VetClinic_backend.Dto.UserDto
{
    public class UserDetailsDto
    {
        [Required(AllowEmptyStrings = true)]
        [DefaultValue("")]
        [RegularExpression(@"^[a-zA-Z0-9\.\-_]{1,}@[a-zA-Z0-9\-_]{1,}\.[a-zA-Z\.]{1,}$")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DefaultValue("")]
        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ]{3,60}")]
        public string? Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DefaultValue("")]
        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ]{3,60}$")]
        public string? Surname { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DefaultValue("")]
        [RegularExpression(@"^[0-9]{9,9}$")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DefaultValue(4)]
        public int Role { get; set; }

    }
}
