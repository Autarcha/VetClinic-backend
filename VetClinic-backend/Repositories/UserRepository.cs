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

        public IQueryable<User>? GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.Id);
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
            var users = GetAllUsers();
            var result = await users.FirstOrDefaultAsync(x => x.Email == email);
            if (result is null)
                return result;

            var isValidPassword = BCrypt.Net.BCrypt.Verify(password, result.Password);

            if (isValidPassword)
            {
                return result;
            }
            return null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
