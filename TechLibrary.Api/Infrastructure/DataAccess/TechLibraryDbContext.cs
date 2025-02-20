using Microsoft.EntityFrameworkCore;
using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.Api.Infrastructure.DataAccess
{
    public class TechLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\dev\\TechLibraryDb.db");
        }
    }
}
