﻿// <auto-generated />
using System;
using EMarketMaker.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMarketMaker.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220918174025_basket6")]
    partial class basket6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EMarketMaker.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 9, 18, 20, 40, 25, 575, DateTimeKind.Local).AddTicks(4521),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 9, 18, 20, 40, 25, 575, DateTimeKind.Local).AddTicks(4530),
                            Name = "Kitaplar"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 9, 18, 20, 40, 25, 575, DateTimeKind.Local).AddTicks(4531),
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("EMarketMaker.Core.Models.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Baskets", (string)null);
                });

            modelBuilder.Entity("EMarketMaker.Core.Models.BasketProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketProducts", (string)null);
                });

            modelBuilder.Entity("EMarketMaker.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AspId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EMarketMaker.Core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 9, 18, 20, 40, 25, 575, DateTimeKind.Local).AddTicks(4670),
                            Name = "Kalem 1",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 9, 18, 20, 40, 25, 575, DateTimeKind.Local).AddTicks(4671),
                            Name = "Kalem 2",
                            Price = 300m,
                            Stock = 40
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 9, 18, 20, 40, 25, 575, DateTimeKind.Local).AddTicks(4673),
                            Name = "Kalem 3",
                            Price = 600m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 9, 18, 20, 40, 25, 575, DateTimeKind.Local).AddTicks(4674),
                            Name = "Kitap 1",
                            Price = 1000m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 9, 18, 20, 40, 25, 575, DateTimeKind.Local).AddTicks(4676),
                            Name = "Kitap 2",
                            Price = 60m,
                            Stock = 10
                        });
                });

            modelBuilder.Entity("EMarketMaker.Core.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Kırmızı",
                            Height = 100,
                            ProductId = 1,
                            Width = 200
                        },
                        new
                        {
                            Id = 2,
                            Color = "Mavi",
                            Height = 150,
                            ProductId = 2,
                            Width = 250
                        });
                });

            modelBuilder.Entity("EMarketMaker.Core.Models.BasketProduct", b =>
                {
                    b.HasOne("EMarketMaker.Core.Models.Basket", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMarketMaker.Core.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EMarketMaker.Core.Product", b =>
                {
                    b.HasOne("EMarketMaker.Core.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EMarketMaker.Core.ProductFeature", b =>
                {
                    b.HasOne("EMarketMaker.Core.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("EMarketMaker.Core.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EMarketMaker.Core.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EMarketMaker.Core.Product", b =>
                {
                    b.Navigation("ProductFeature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
