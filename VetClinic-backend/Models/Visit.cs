namespace VetClinic_backend.Models
{
    public enum VisitStatus
    {
        Scheduled = 1,
        Canceled = 2,
        Ended = 4
    }
    public class Visit
    {
        public int Id { get; set; }
        public User Employee { get; set; }
        public User Customer { get; set; }
        public Animal Animal { get; set; }
        public DateTime VisitDateTime { get; set; }
        public VisitStatus VisitStatus { get; set; }
        public VisitDetails VisitDetails { get; set; }
    }
}
