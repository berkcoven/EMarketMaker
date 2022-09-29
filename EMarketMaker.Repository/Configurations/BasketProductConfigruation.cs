using EMarketMaker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Repository.Configurations
{
    public class BasketProductConfigruation:IEntityTypeConfiguration<BasketProduct>
    {
        public void Configure(EntityTypeBuilder<BasketProduct> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasKey(x => new { x.ProductId,x.BasketId});
            builder.Property(x => x.Id).UseIdentityColumn();
            //builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("BasketProducts");
        }
    }
}
