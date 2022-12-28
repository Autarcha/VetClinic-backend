using Microsoft.EntityFrameworkCore;
using VetClinic_backend.Configurations;
using VetClinic_backend.Models;

namespace VetClinic_backend.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }
    }
}
