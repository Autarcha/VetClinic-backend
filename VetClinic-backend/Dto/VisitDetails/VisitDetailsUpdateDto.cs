using System.ComponentModel.DataAnnotations;

namespace VetClinic_backend.Dto.VisitDetails
{
    public class VisitDetailsUpdateDto
    {
        [MaxLength(60)]
        public string? VisitPurpose { get; set; }
        [MaxLength(800)]
        public string? Description { get; set; }
        [MaxLength(500)]
        public string? AppliedDrugs { get; set; }
        [MaxLength(500)]
        public string? Prescription { get; set; }
        [MaxLength(500)]
        public string? Recommendations { get; set; }
        [Range(0d, 1000000d)]
        public double? Bill { get; set; }
    }
}
