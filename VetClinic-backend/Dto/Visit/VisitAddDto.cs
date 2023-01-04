using System.ComponentModel.DataAnnotations.Schema;
using VetClinic_backend.Models;

namespace VetClinic_backend.Dto.Visit
{
    public class VisitAddDto
    {
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int? AnimalID { get; set; }
        public DateTime VisitDateTime { get; set; }
        public VisitStatus VisitStatus { get; set; }
    }
}
