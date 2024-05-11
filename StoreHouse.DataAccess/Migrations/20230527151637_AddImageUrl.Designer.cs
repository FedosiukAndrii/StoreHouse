﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreHouse.DataAccess.Data;

#nullable disable

namespace StoreHouse.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230527151637_AddImageUrl")]
    partial class AddImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreHouse.Models.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Shoes",
                            Order = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Jackets",
                            Order = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Shirts",
                            Order = 3
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "T-Shirts",
                            Order = 4
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Bags",
                            Order = 5
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Trousers",
                            Order = 6
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Jeans",
                            Order = 7
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "Dresses",
                            Order = 8
                        });
                });

            modelBuilder.Entity("StoreHouse.Models.Entities.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<string>("CssCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ColorId");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            ColorId = 1,
                            CssCode = "FFFFFF",
                            Order = 1,
                            Title = "White"
                        },
                        new
                        {
                            ColorId = 2,
                            CssCode = "808080",
                            Order = 2,
                            Title = "Gray"
                        },
                        new
                        {
                            ColorId = 3,
                            CssCode = "006400",
                            Order = 3,
                            Title = "Dark Green"
                        },
                        new
                        {
                            ColorId = 4,
                            CssCode = "F5F5DC",
                            Order = 4,
                            Title = "Beige"
                        },
                        new
                        {
                            ColorId = 5,
                            CssCode = "0000FF",
                            Order = 5,
                            Title = "Blue"
                        },
                        new
                        {
                            ColorId = 6,
                            CssCode = "6A6957",
                            Order = 6,
                            Title = "Gray green"
                        },
                        new
                        {
                            ColorId = 7,
                            CssCode = "000000",
                            Order = 7,
                            Title = "Black"
                        },
                        new
                        {
                            ColorId = 8,
                            CssCode = "293141",
                            Order = 8,
                            Title = "Navy"
                        });
                });

            modelBuilder.Entity("StoreHouse.Models.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 3,
                            Description = "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.",
                            Price = 1499.0,
                            Title = "COTTON - LINEN SHIRT"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 6,
                            Description = "Wide-fit trousers made of lightweight technical fabric. Elasticated waistband with front pleats and metal ring detail. Front pockets and back welt pockets. Zip fly front fastening and snap button fastening.",
                            Price = 1899.0,
                            Title = "PLEATED TECHNICAL TROUSERS"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            Description = "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.",
                            Price = 1499.0,
                            Title = "STRIPED CROCHET SHIRT"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 6,
                            Description = "Trousers featuring an adjustable elastic waistband with drawstrings. Front pockets and rear welt pockets.",
                            Price = 1499.0,
                            Title = "TEXTURED TROUSERS"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 6,
                            Description = "Relaxed-fit shirt made of a linen blend. Button-down collar. Long sleeves with buttoned cuffs. Chest patch pocket. Button-up front.",
                            Price = 1499.0,
                            Title = "COTTON - LINEN TROUSERS"
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 3,
                            Description = "Carrot fit trousers with front pockets, rear welt pockets and front zip fly and top button fastening.",
                            Price = 1499.0,
                            Title = "PLEATED CHINO TROUSERS"
                        });
                });

            modelBuilder.Entity("StoreHouse.Models.Entities.ProductColor", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ColorId");

                    b.HasIndex("ColorId");

                    b.ToTable("ProductColor");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ColorId = 1
                        },
                        new
                        {
                            ProductId = 1,
                            ColorId = 3
                        },
                        new
                        {
                            ProductId = 1,
                            ColorId = 4
                        },
                        new
                        {
                            ProductId = 1,
                            ColorId = 7
                        },
                        new
                        {
                            ProductId = 1,
                            ColorId = 8
                        },
                        new
                        {
                            ProductId = 2,
                            ColorId = 4
                        },
                        new
                        {
                            ProductId = 2,
                            ColorId = 6
                        },
                        new
                        {
                            ProductId = 2,
                            ColorId = 7
                        },
                        new
                        {
                            ProductId = 6,
                            ColorId = 1
                        },
                        new
                        {
                            ProductId = 6,
                            ColorId = 4
                        },
                        new
                        {
                            ProductId = 6,
                            ColorId = 8
                        });
                });

            modelBuilder.Entity("StoreHouse.Models.Entities.Product", b =>
                {
                    b.HasOne("StoreHouse.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("StoreHouse.Models.Entities.ProductColor", b =>
                {
                    b.HasOne("StoreHouse.Models.Entities.Color", "Color")
                        .WithMany("ProductColors")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreHouse.Models.Entities.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StoreHouse.Models.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StoreHouse.Models.Entities.Color", b =>
                {
                    b.Navigation("ProductColors");
                });

            modelBuilder.Entity("StoreHouse.Models.Entities.Product", b =>
                {
                    b.Navigation("ProductColors");
                });
#pragma warning restore 612, 618
        }
    }
}
