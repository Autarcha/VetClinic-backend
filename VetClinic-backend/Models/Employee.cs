using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic_backend.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string? Specialization { get; set; }

        [ForeignKey("AdressId")]
        public virtual User User { get; set; }
    }
}
