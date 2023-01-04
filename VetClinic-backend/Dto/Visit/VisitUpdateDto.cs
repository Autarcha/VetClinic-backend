using VetClinic_backend.Models;

namespace VetClinic_backend.Dto.Visit
{
    public class VisitUpdateDto
    {
        public int EmployeeId { get; set; }
        public int? AnimalID { get; set; }
        public DateTime VisitDateTime { get; set; }
        public VisitStatus VisitStatus { get; set; }
    }
}
