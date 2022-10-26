using VetClinic_backend.Enums;

namespace VetClinic_backend.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genders Gender { get; set; }
        public DateTime? BirthDate { get; set; }    
        public Specie Specie { get; set; }
        public User User { get; set; }
        public ICollection<Examination> Examinations { get; set; }
        public ICollection<Visit> Visits { get; set; }
    }
}
