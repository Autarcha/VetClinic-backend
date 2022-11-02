using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IUserInterface
    {
        public ICollection<User> GetAllUsers();
        User GetUser(int userId);
        User Getuser(string email);
        User GetUser(string name, string surname);
        bool UserExists(int userId);

    }
}
