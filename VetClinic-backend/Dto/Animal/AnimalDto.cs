using VetClinic_backend.Models;
using VetClinic_backend.Dto.User;

namespace VetClinic_backend.Dto.Animal
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public UserDto Owner { get; set; }
        public string Name { get; set; }
        public string Specie { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
