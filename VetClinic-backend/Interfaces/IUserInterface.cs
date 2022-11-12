using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IUserInterface
    {
        public ICollection<User> GetAllUsers();
        User GetUser(int userId);
        User GetUser(string email);
        User GetUser(string name, string surname);
        bool UserExists(int userId);
        bool CreateUser (User user);
        bool Save();

    }
}
