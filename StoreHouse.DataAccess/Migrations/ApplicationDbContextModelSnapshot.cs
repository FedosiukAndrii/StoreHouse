﻿// <auto-generated />
using StoreHouse.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace StoreHouse.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreHouse.Web.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
#pragma warning restore 612, 618
        }
    }
}
