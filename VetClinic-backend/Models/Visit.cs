using VetClinic_backend.Enums;

namespace VetClinic_backend.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public TimeSpan VisitTime { get; set; }
        public Status Status { get; set; }
        public Animal Animal { get; set; }
        public User User { get; set; }
        public Employee Employee { get; set; }
        public virtual Examination Examination { get; set; }
    }
}
