using Microsoft.EntityFrameworkCore;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 1,
                Name = "Shoes",
                Order = 1
            },
            new Category
            {
                CategoryId = 2,
                Name = "Jackets",
                Order = 2
            },
            new Category
            {
                CategoryId = 3,
                Name = "Shirts",
                Order = 3
            },
            new Category
            {
                CategoryId = 4,
                Name = "T-Shirts",
                Order = 4
            },
            new Category
            {
                CategoryId = 5,
                Name = "Bags",
                Order = 5
            },
            new Category
            {
                CategoryId = 6,
                Name = "Trousers",
                Order = 6
            },
            new Category
            {
                CategoryId = 7,
                Name = "Jeans",
                Order = 7
            },
            new Category
            {
                CategoryId = 8,
                Name = "Dresses",
                Order = 8
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
