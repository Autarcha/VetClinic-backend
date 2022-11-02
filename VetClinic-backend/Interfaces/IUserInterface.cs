using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IUserInterface
    {
        public ICollection<User> GetAllUsers();
        User GetUser(int id);
        User Getuser(string email);
        User GetUser(string name, string surname);
        Address GetUserAddress(int id);
    }
}
