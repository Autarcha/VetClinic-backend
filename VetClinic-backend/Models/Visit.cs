using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic_backend.Models
{
    public enum VisitStatus
    {
        Scheduled = 1,
        Canceled = 2,
        Ended = 4
    }
    public class Visit
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual User Employee { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual User Customer { get; set; }

        public Animal? Animal { get; set; }
        public DateTime VisitDateTime { get; set; }
        public VisitStatus VisitStatus { get; set; }
        public int? VisitDetailsId { get; set; }
        [ForeignKey("VisitDetailsId")]
        public VisitDetails? VisitDetails { get; set; }

    }
}
