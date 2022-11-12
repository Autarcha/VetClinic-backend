using VetClinic_backend.Models;

namespace VetClinic_backend.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserById(int id);
        public Task<User?> GetUserByEmail(string email);
        public Task<User?> LoginUser(string email, string password);
        public Task<User?> AddUser(User user);
        public Task<User?> UpdateUser(User user);

    }
}
