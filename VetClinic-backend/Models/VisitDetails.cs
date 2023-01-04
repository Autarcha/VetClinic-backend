using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic_backend.Models
{
    public class VisitDetails
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public Visit Visit { get; set; }
        public string VisitPurpose { get; set; }
        public string Description { get; set; }
        public string? AppliedDrugs { get; set; }
        public string? Prescription { get; set; }
        public string? Recommendations { get; set; }
        public double Bill { get; set; }

    }
}
