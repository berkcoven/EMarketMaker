
using Microsoft.EntityFrameworkCore;
using System;

namespace EMarketMaker.MVCUser.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //var p = new Product() { ProductFeature = new ProductFeature() { } };

        }
    }
}