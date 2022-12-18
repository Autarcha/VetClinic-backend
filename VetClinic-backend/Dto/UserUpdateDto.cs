using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace VetClinic_backend.Dto
{
    public class UserUpdateDto
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
    }
}
