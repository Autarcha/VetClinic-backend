using VetClinic_backend.Dto.Visit;

namespace VetClinic_backend.Dto.VisitDetails
{
    public class VisitAddUpdateDto
    {
        public int VisitId { get; set; }
        public string VisitPurpose { get; set; }
        public string Description { get; set; }
        public string? AppliedDrugs { get; set; }
        public string? Prescription { get; set; }
        public string? Recommendations { get; set; }
    }
}
