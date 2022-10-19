using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic_backend.Models
{
    public class Examination
    {
        public int Id { get; set; }
        public string ExaminationDetails { get; set; }
        public string Diagnosis { get; set; }
        public Animal Animal { get; set; }
        public Employee Employee { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
