using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User?> GetUserById(int id);
        public Task<User?> GetUserByName(string name, string surname);
        public Task<User?> LoginUser(string email, string password);
        public Task<User?> AddUser(User user);
        public Task<User?> UpdateUser(User user);
        public Task<bool> SaveChangesAsync();

    }
}
