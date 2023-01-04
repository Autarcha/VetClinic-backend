using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using VetClinic_backend.Data;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository(RepositoryContext context) : base(context) { }


        public IQueryable<User>? GetAllUsers()
        {
            var result = GetAll().OrderBy(u => u.Id);
            return result;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var result = await GetAll().FirstOrDefaultAsync(u => u.Email == email);
            return result;
        }


        public async Task<User?> GetUserById(int id)
        {
        var result = await GetAll().FirstOrDefaultAsync(u => u.Id == id);
        return result;
        }

        public async Task<User?> AddUser(User user)
        {
            var newUser = await AddAsync(user);
            await SaveChangesAsync();
            return newUser;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var updateUser = UpdateAsync(user);
            await SaveChangesAsync();
            return updateUser.Result;
        }

        public async Task<User?> LoginUser(string email, string password)
        {
            var users = GetAllUsers();
            var result = await users.FirstOrDefaultAsync(u => u.Email == email);
            if (result is null)
                return result;

            var isValidPassword = BCrypt.Net.BCrypt.Verify(password, result.Password);

            if (isValidPassword)
            {
                return result;
            }
            return null;
        }

        public async Task<User?> DeleteUser(User user)
        {
            await RemoveAsync(user);
            await SaveChangesAsync();
            return user;
        }
    }
}
