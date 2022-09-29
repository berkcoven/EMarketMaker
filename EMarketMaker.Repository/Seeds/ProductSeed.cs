using EMarketMaker.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id=1,
                CategoryId=1,
                Name="Kalem 1",
                Price=100,
                Stock=20,
                CreatedDate=DateTime.Now,
                Description=""
            }, new Product
            {
                Id = 2,
                CategoryId = 1,
                Name = "Kalem 2",
                Price = 300,
                Stock = 40,
                CreatedDate = DateTime.Now,
                Description = ""
            }, new Product
            {
                Id = 3,
                CategoryId = 1,
                Name = "Kalem 3",
                Price = 600,
                Stock = 30,
                CreatedDate = DateTime.Now,
                Description = ""
            }, new Product
            {
                Id = 4,
                CategoryId = 2,
                Name = "Kitap 1",
                Price = 1000,
                Stock = 10,
                CreatedDate = DateTime.Now,
                Description = ""
            }, new Product
            {
                Id = 5,
                CategoryId = 2,
                Name = "Kitap 2",
                Price = 60,
                Stock = 10,
                CreatedDate = DateTime.Now,
                Description = ""
            }



            );
        }
    }
}
