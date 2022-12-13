using VetClinic_backend.Models;

namespace VetClinic_backend.Dto
{
    public class UserDto
    {
        // User data known public on service
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Role? Role { get; set; }
    }
}
