using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IUserInterface
    {
        public ICollection<User> GetAllUsers();
    }
}
