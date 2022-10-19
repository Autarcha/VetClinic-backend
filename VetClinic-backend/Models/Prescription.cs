namespace VetClinic_backend.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Recommendations { get; set; }
        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }
        public virtual Examination Examination { get; set; }
    }
}
