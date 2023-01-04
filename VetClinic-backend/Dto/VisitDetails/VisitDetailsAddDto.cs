using System.ComponentModel.DataAnnotations;

namespace VetClinic_backend.Dto.VisitDetails
{
    public class VisitDetailsAddDto
    {
        public int VisitId { get; set; }
        [Required]
        public string VisitPurpose { get; set; }
        [Required]
        public string Description { get; set; }
        public string? AppliedDrugs { get; set; }
        public string? Prescription { get; set; }
        public string? Recommendations { get; set; }
        [Range(0d, 1000000d)]
        public double Bill { get; set; }
    }
}
