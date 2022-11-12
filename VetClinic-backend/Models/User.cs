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
        User = 4
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? PostCode { get; set; }
        public Role Role { get; set; }
    }
}