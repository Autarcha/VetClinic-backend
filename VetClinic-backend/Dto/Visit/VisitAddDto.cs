using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VetClinic_backend.Dto.Visit
{
    public class VisitAddDto
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public int? AnimalID { get; set; }
        [Required]
        public DateTime VisitDateTime { get; set; }
    }
}
