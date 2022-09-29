using EMarketMaker.Core;
using EMarketMaker.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EMarketMaker.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)   
        {
            //var p = new Product() { ProductFeature = new ProductFeature() { } };

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketProduct> BasketProducts{ get; set; }
        public DbSet<Basket> Basket{ get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//IEntityTypeConfiguration kullananları alıyor
            //modelBuilder.ApplyConfiguration(new ProductConfiguration()); tekli eklem
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1

            }, new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 150,
                Width = 250,
                ProductId = 2

            }


            );


            base.OnModelCreating(modelBuilder); 
        }
    }
}
