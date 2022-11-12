﻿using VetClinic_backend.Data;
using VetClinic_backend.Interfaces;
using VetClinic_backend.Models;

namespace VetClinic_backend.Repositories
{
    public class UserRepository : IUserInterface
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<User> GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User GetUser(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User GetUser(string name, string surname)
        {
            return _context.Users.Where(u => u.Name == name && u.Surname == surname).FirstOrDefault();
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
