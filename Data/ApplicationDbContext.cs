using FindIt.Models;
using Microsoft.EntityFrameworkCore;

namespace FindIt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignore ConfirmPassword property
            modelBuilder.Entity<UserModel>().Ignore(p => p.ConfirmPassword);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ItemModel> Items { get; set; }
    }
}
