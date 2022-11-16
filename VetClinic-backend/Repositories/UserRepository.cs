using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using VetClinic_backend.Data;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _context.Users.OrderBy(u => u.Id).ToListAsync();
            return users;
        }

        public async Task<User?> GetUserByName(string name, string surname)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Name == name && u.Surname == surname);
            return result;
        }


        public async Task<User?> GetUserById(int id)
        {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return result;
        }

        public async Task<User?> AddUser(User user)
        {
            var newUser = await _context.Users.AddAsync(user);
            return newUser.Entity;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var updateUser = _context.Users.Update(user);
            return updateUser.Entity;
        }

        public async Task<User?> LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
