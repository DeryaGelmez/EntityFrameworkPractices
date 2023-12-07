using EntityFrameworkPractices.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractices
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}

