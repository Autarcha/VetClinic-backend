using System.ComponentModel.DataAnnotations.Schema;
using VetClinic_backend.Dto.Animal;
using VetClinic_backend.Dto.User;
using VetClinic_backend.Dto.VisitDetails;
using VetClinic_backend.Models;

namespace VetClinic_backend.Dto.Visit
{
    public class VisitDto
    {
        public int Id { get; set; }
        public UserDto Employee { get; set; }
        public UserDto Customer { get; set; }
        public AnimalDto? Animal { get; set; }
        public DateTime VisitDateTime { get; set; }
        public VisitStatus VisitStatus { get; set; }
        public VisitDetailsDto? VisitDetails { get; set; }
    }
}
