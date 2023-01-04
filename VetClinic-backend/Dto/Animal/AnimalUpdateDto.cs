using System.ComponentModel.DataAnnotations;

namespace VetClinic_backend.Dto.Animal
{
    public class AnimalUpdateDto
    {
        [RegularExpression(@"^[a-zA-ZąęółżźćńśĄĘÓŻŹĆŃŁŚ ]{3,60}")]
        public string? Name { get; set; }
        public int? OwnerID { get; set; }

        [MaxLength(50)]
        public string? Specie { get; set; }
        [MaxLength(500)]
        public string? AdditionalInfo { get; set; }

    }
}
