namespace VetClinic_backend.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public TimeOnly VisitTime { get; set; }
        public enum Status { }
    }
}
