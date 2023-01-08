using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VetClinic_backend.Dto.VisitDetails
{
    public class VisitDetailsAddDto
    {
        [Required]
        [MaxLength(60)]
        public string VisitPurpose { get; set; }
        [Required]
        [MaxLength(800)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string? AppliedDrugs { get; set; }
        [MaxLength(500)]
        public string? Prescription { get; set; }
        [MaxLength(500)]
        public string? Recommendations { get; set; }
        [Range(0d, 1000000d)]
        public double Bill { get; set; }
    }
}
