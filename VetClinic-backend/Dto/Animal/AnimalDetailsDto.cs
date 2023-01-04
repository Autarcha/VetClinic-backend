using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using VetClinic_backend.Models;

namespace VetClinic_backend.Dto.Animal
{
    public class AnimalDetailsDto
    {
        [Required(AllowEmptyStrings = true)]
        [DefaultValue("")]
        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ ]{3,60}")]
        public string Name { get; set; }
        [Required]
        public int OwnerID { get; set; }

        [Required]
        public string Specie { get; set; }

        public string? AdditionalInfo { get; set; }

    }
}
