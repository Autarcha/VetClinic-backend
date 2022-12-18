using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace VetClinic_backend.Dto
{
    public class UserChangePasswordDto
    {
        [Required(AllowEmptyStrings = true)]
        [DefaultValue("")]
        public string? OldPassword { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DefaultValue("")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        public string? NewPassword { get; set; }
    }
}
