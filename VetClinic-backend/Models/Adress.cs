using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic_backend.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public virtual User User { get; set; }
    }
}
