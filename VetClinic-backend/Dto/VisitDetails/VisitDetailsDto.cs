using System.ComponentModel.DataAnnotations.Schema;
using VetClinic_backend.Dto.Visit;

namespace VetClinic_backend.Dto.VisitDetails
{
    public class VisitDetailsDto
    {
        public int Id { get; set; }
        public VisitDto Visit { get; set; }
        public string VisitPurpose { get; set; }
        public string Description { get; set; }
        public string? AppliedDrugs { get; set; }
        public string? Prescription { get; set; }
        public string? Recommendations { get; set; }
    }
}
