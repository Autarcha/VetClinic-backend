namespace VetClinic_backend.Models
{
    public class MedicinePrescriptioncs
    {
        public int MedicineId { get; set; }
        public int PrescriptionId { get; set; }
        public Medicine Medicine { get; set; }
        public Prescription Prescription { get; set; }
    }
}
