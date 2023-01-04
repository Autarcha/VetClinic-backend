using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace VetClinic_backend.Models
{
    [Flags]
    public enum Role
    {
        Admin = 1,
        Employee = 2,
        Customer = 4
    }
    public class User
    {
        //User model class
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }

        public ICollection<Animal> Animals { get; set; }
        public ICollection<Visit> EmployeeVisits { get; set; }
        public ICollection<Visit> CustomerVisits { get; set; }
    }
}