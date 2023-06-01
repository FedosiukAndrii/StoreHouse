using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColorImage> Images { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<ProductColor>()
                .HasKey(pc => new { pc.ProductId, pc.ColorId });

            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Color)
                .WithMany(c => c.ProductColors)
                .HasForeignKey(pc => pc.ColorId);

            modelBuilder.Entity<Product>()
                 .HasOne(p => p.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<ProductColor>()
                .HasMany(pc => pc.Images)
                .WithOne(i => i.ProductColor)
                .HasForeignKey(im => new { im.ProductId, im.ColorId });


            var categories = new[]
            {
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
                }
            };

            var colors = new[]
            {
                new Color
                {
                    ColorId = 1,
                    Title = "White",
                    CssCode = "FFFFFF",
                    Order = 1,
                },
                new Color
                {
                    ColorId = 2,
                    Title = "Gray",
                    CssCode = "808080",
                    Order = 2,
                },
                new Color
                {
                    ColorId = 3,
                    Title = "Dark Green",
                    CssCode = "006400",
                    Order = 3,
                },
                new Color
                {
                    ColorId = 4,
                    Title = "Beige",
                    CssCode = "F5F5DC",
                    Order = 4,
                },
                new Color
                {
                    ColorId = 5,
                    Title = "Blue",
                    CssCode = "0000FF",
                    Order = 5,
                },
                new Color
                {
                    ColorId = 6,
                    Title = "Gray green",
                    CssCode = "6A6957",
                    Order = 6,
                },
                new Color
                {
                    ColorId = 7,
                    Title = "Black",
                    CssCode = "000000",
                    Order = 7,
                },
                new Color
                {
                    ColorId = 8,
                    Title = "Navy",
                    CssCode = "293141",
                    Order = 8,
                }
            };

            var products = new[]
            {
                new Product
                {
                    ProductId = 1,
                    Title = "COTTON - LINEN SHIRT",
                    Description = "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.",
                    Price = 1499,
                    CategoryId = 3
                }
                ,
                new Product
                {
                    ProductId = 2,
                    Title = "PLEATED TECHNICAL TROUSERS",
                    Description = "Wide-fit trousers made of lightweight technical fabric. Elasticated waistband with front pleats and metal ring detail. Front pockets and back welt pockets. Zip fly front fastening and snap button fastening.",
                    Price = 1899,
                    CategoryId = 6
                },
                new Product
                {
                    ProductId = 3,
                    Title = "STRIPED CROCHET SHIRT",
                    Description = "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.",
                    Price = 1499,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 4,
                    Title = "TEXTURED TROUSERS",
                    Description = "Trousers featuring an adjustable elastic waistband with drawstrings. Front pockets and rear welt pockets.",
                    Price = 1499,
                    CategoryId = 6
                },
                new Product
                {
                    ProductId = 5,
                    Title = "COTTON - LINEN TROUSERS",
                    Description = "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.",
                    Price = 1499,
                    CategoryId = 6
                },
                new Product
                {
                    ProductId = 6,
                    Title = "PLEATED CHINO TROUSERS",
                    Description = "Carrot fit trousers with front pockets, rear welt pockets and front zip fly and top button fastening.",
                    Price = 1499,
                    CategoryId = 3
                }
            };

            var productColors = new[]
            {
                new ProductColor{ ProductId = 1, ColorId = 1},
                new ProductColor{ ProductId = 1, ColorId = 3},
                new ProductColor{ ProductId = 1, ColorId = 4},
                new ProductColor{ ProductId = 1, ColorId = 7},
                new ProductColor{ ProductId = 1, ColorId = 8},
                new ProductColor{ ProductId = 2, ColorId = 4},
                new ProductColor{ ProductId = 2, ColorId = 6},
                new ProductColor{ ProductId = 2, ColorId = 7},
                new ProductColor{ ProductId = 6, ColorId = 1},
                new ProductColor{ ProductId = 6, ColorId = 4},
                new ProductColor{ ProductId = 6, ColorId = 8},
            };

            var sizes = new[]
            {
                new Size{SizeId = 1, Title = "S", Order = 1},
                new Size{SizeId = 2, Title = "M", Order = 2},
                new Size{SizeId = 3, Title = "L", Order = 3},
                new Size{SizeId = 4, Title = "XL", Order = 4},
                new Size{SizeId = 5, Title = "XXL", Order = 5},
            };

            modelBuilder.Entity<Size>().HasData(sizes);

            modelBuilder.Entity<Category>().HasData(categories);

            modelBuilder.Entity<Color>().HasData(colors);

            modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.Entity<ProductColor>().HasData(productColors);

            base.OnModelCreating(modelBuilder);
        }
    }
}
