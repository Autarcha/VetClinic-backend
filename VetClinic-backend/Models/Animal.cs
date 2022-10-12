namespace VetClinic_backend.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public enum Gender { }
        public DateTime? BirthDate { get; set; }    
    }
}
