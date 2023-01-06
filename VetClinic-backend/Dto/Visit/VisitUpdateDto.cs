using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using VetClinic_backend.Models;

namespace VetClinic_backend.Dto.Visit
{
    public class VisitUpdateDto
    {
        [Required]
        public int EmployeeId { get; set; }
        public int? AnimalId { get; set; }
        public DateTime? VisitDateTime { get; set; }
        public int? VisitStatus { get; set; }
    }
}
