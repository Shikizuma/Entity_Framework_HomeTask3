using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EntityDatabase : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<KeyParams> KeyParams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }

        public EntityDatabase()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=HomeTaskThird; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}